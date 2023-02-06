using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using AutoDabiServiceAPI.Data;
using AutoDabiServiceAPI.DTOs;
using AutoDabiServiceAPI.DTOs.UserDtos;
using AutoDabiServiceAPI.Models;
using EasyCaching.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Hosting;
using AspNetCore.Reporting;
using System.IO;
using AutoDabiServiceAPI.Models.Rent;
using AutoDabiServiceAPI.Mapper;
using AutoDabiServiceAPI.Models.Protocol;

namespace AutoDabiServiceAPI.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IEasyCachingProviderFactory _easyCachingProviderFactory;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private static readonly string emptyImage = "iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mP8z/C/HgAGgwJ/lK3Q6wAAAABJRU5ErkJggg==";

        public CarRepository(ApplicationDbContext context, IEasyCachingProviderFactory easyCachingProviderFactory, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _easyCachingProviderFactory = easyCachingProviderFactory;
            _webHostEnvironment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        //
        // Summary:
        //     Finds all cars.
        //
        // Returns:
        //     All cars.
        public async Task<IEnumerable<Car>> GetAllCars()
        {
            string cacheKey = "AllCars";
            var cache = _easyCachingProviderFactory.GetCachingProvider("default");

            var result = await cache.GetAsync(cacheKey, async () => await _context.Cars.Include(car => car.CarDamages).ToListAsync(), TimeSpan.FromSeconds(5));

            return result?.Value;
        }

        //
        // Summary:
        //     Finds all available cars.
        //
        // Returns:
        //     All available cars.
        public async Task<IEnumerable<Car>> GetAllAvailableCars()
        {
            string cacheKey = "AllAvailableCars";
            var cache = _easyCachingProviderFactory.GetCachingProvider("default");
            
            var result = await cache.GetAsync(cacheKey, async () => await _context.Cars.Where(car => car.Available == true).Include(car => car.CarDamages).ToListAsync(), TimeSpan.FromSeconds(5));

            return result?.Value;
        }

        //
        // Summary:
        //     Finds all rented cars.
        //
        // Returns:
        //     All rented cars.
        public async Task<IEnumerable<Car>> GetAllRentedCars()
        {
            string cacheKey = "AllRentedCars";
            var cache = _easyCachingProviderFactory.GetCachingProvider("default");

            var result = await cache.GetAsync(cacheKey, async () => await _context.Cars.Where(car => car.Available == false).Include(car => car.CarDamages).ToListAsync(), TimeSpan.FromSeconds(5));

            return result?.Value;
        }

        //
        // Summary:
        //     Finds car and set available to false.
        //     Creates report.
        //
        // Parameters:
        //   id:
        //     The car id to search for and rent.
        //
        // Returns:
        //     Generated report.
        public async Task<ResultInfo> RentCar(RentCarModel rentCarModel)
        {
            Car car = await _context.Cars.FindAsync(rentCarModel.Car.Id);

            if (car == null)
            {
                return new ResultInfo(StatusType.Failed, "Nie znaleziono samochodu.");
            }

            if (!car.Available)
            {
                return new ResultInfo(StatusType.Failed, "Samochód jest już wypożyczony. Nie można go wypożyczyć.");
            }

            car.Available = false;

            _context.Entry(car).State = EntityState.Modified;

            try
            {
                string mimtype = "";
                int extension = 1;
                var path = $"{_webHostEnvironment.WebRootPath}\\Reports\\AutoDabiReport.rdlc";
                var protocol = new Protocol();
                protocol.Car = rentCarModel.Car;
                protocol.Date = rentCarModel.StartDate;
                protocol.IsClearInside = rentCarModel.isCleanInside;
                protocol.IsClearOutside = rentCarModel.isCleanOutside;
                protocol.Place = rentCarModel.Place;
                protocol.Time = DateTime.Now.ToShortTimeString();
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                LocalReport localReport = new LocalReport(path);
                if (rentCarModel.TenantBusiness == null)
                {
                    localReport.AddDataSource("TenantInfo", ReportMapper.TenantPrivateMap(rentCarModel.TenantPrivate, rentCarModel.Hirer));
                    protocol.User = rentCarModel.TenantPrivate.Name + rentCarModel.TenantPrivate.LastName;
                }
                else
                {
                    localReport.AddDataSource("TenantInfo", ReportMapper.TenantBusinesssMap(rentCarModel.TenantBusiness, rentCarModel.Hirer));
                    protocol.User = rentCarModel.TenantBusiness.Name;
                }
                localReport.AddDataSource("ContractInfo", ReportMapper.ContractInfoMap(rentCarModel.ContractNumber, rentCarModel.ContractNumber, rentCarModel.StartDate));
                localReport.AddDataSource("DriverInfo", ReportMapper.DriverInfo(rentCarModel.Driver));
                localReport.AddDataSource("LeasePeriod", ReportMapper.LeasePeriod(rentCarModel.StartDate, DateTime.Now.ToShortTimeString()));
                localReport.AddDataSource("LeaseRent", ReportMapper.LeaseRent());
                localReport.AddDataSource("LeaseSubject", ReportMapper.LeaseSubject(rentCarModel.Car));
                localReport.AddDataSource("IssuedItems", ReportMapper.IssuedItem());
                localReport.AddDataSource("AdditionalService", ReportMapper.AdditionalService());
                localReport.AddDataSource("DriverSignatures", ReportMapper.DriverSignatures(rentCarModel.StartDate));
                localReport.AddDataSource("Car", ReportMapper.Car(rentCarModel.Car));
                localReport.AddDataSource("Protocol", ReportMapper.ProtocolRelease(protocol));
                localReport.AddDataSource("HandedOverWithCar", ReportMapper.HandedOverWith(rentCarModel.HandedOverWithCar));
                localReport.AddDataSource("ReleaseDamage", ReportMapper.Damage(rentCarModel.Car.CarDamages.ToList()));
                localReport.AddDataSource("ReturnDamage", ReportMapper.Damage(rentCarModel.Car.CarDamages.ToList()));
                localReport.AddDataSource("ReleaseDamageSignature", ReportMapper.DamageSignature());
                localReport.AddDataSource("ReturnDamageSignature", ReportMapper.DamageSignature());
                var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);

                _context.Cars.Update(car);
                _context.SaveChanges();

                return new ResultInfo(StatusType.Success, result);
            }
            catch (DbUpdateConcurrencyException)
            {

                return new ResultInfo(StatusType.Failed, "Nie udało się wypożyczyć samochodu. Spróbuj ponownie za chwilę.");
            }

        }

        //
        // Summary:
        //     Finds car and set available to true.
        //
        // Parameters:
        //   id:
        //     The car id to search for and return.
        //
        // Returns:
        //     ResultInfo.
        public async Task<ResultInfo> ReturnCar(ReturnCarModel returnCarModel)
        {
            Car car = await _context.Cars.FindAsync(returnCarModel.Car.Id);

            if (car == null)
            {
                return new ResultInfo(StatusType.Failed, "Nie znaleziono samochodu.");
            }

            if (car.Available)
            {
                return new ResultInfo(StatusType.Failed, "Samochód został już zwrócony. Nie można go zwrócić ponownie.");
            }

            car.Available = true;

            _context.Entry(car).State = EntityState.Modified;

            try
            {
                _context.Cars.Update(car);
                _context.SaveChanges();

                string mimtype = "";
                int extension = 1;
                var path = $"{_webHostEnvironment.WebRootPath}\\Reports\\AutoDabiReport.rdlc";
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                LocalReport localReport = new LocalReport(path);
                localReport.AddDataSource("ContractInfo", ReportMapper.ContractInfoMap("123", "123", "12.12.2012"));
                localReport.AddDataSource("TenantInfo", ReportMapper.TenantPrivateMap(new TenantPrivate(), new Hirer()));
                localReport.AddDataSource("DriverInfo", ReportMapper.DriverInfo(new List<Driver>()));
                //localReport.AddDataSource("LeasePeriod", ReportMapper.LeasePeriod());
                localReport.AddDataSource("LeaseRent", ReportMapper.LeaseRent());
                localReport.AddDataSource("LeaseSubject", ReportMapper.LeaseSubject(returnCarModel.Car));
                localReport.AddDataSource("AdditionalService", ReportMapper.AdditionalService());
                localReport.AddDataSource("IssuedItems", ReportMapper.IssuedItem());
                //localReport.AddDataSource("DriverSignatures", ReportMapper.DriverSignatures());
                localReport.AddDataSource("Car", ReportMapper.Car(returnCarModel.Car));
                //localReport.AddDataSource("Protocol", ReportMapper.Protocol());
                //localReport.AddDataSource("HandedOverWithCar", ReportMapper.HandedOverWith());
                localReport.AddDataSource("ReleaseDamage", ReportMapper.Damage(returnCarModel.Car.CarDamages.ToList()));
                localReport.AddDataSource("ReturnDamage", ReportMapper.Damage(returnCarModel.Car.CarDamages.ToList()));
                localReport.AddDataSource("ReleaseDamageSignature", ReportMapper.DamageSignature());
                localReport.AddDataSource("ReturnDamageSignature", ReportMapper.DamageSignature());
                var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);

                return new ResultInfo(StatusType.Success, result);
            }
            catch (DbUpdateConcurrencyException)
            {

                return new ResultInfo(StatusType.Failed, "Nie udało się zwrócić samochodu. Spróbuj ponownie za chwilę.");
            }
        }
    }
}