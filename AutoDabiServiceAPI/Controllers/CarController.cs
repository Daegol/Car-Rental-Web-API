using AspNetCore.Reporting;
using AutoDabiServiceAPI.DTOs;
using AutoDabiServiceAPI.Models;
using AutoDabiServiceAPI.Models.Rent;
using AutoDabiServiceAPI.Repositories;
using AutoDabiServiceAPI.Repositories.file;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AutoDabiServiceAPI.Controllers
{
    [Authorize]
    public class CarController : GenericController<Car>
    {
        private readonly ICarRepository _carRepository;
        private readonly IFileRepository _fileRepository;
        public CarController(IGenericRepository<Car> repository, ICarRepository carRepository, IFileRepository fileRepository) : base(repository)
        {
           _carRepository = carRepository;
           _fileRepository = fileRepository;
        }

        public override async Task<IActionResult> GetAll()
        {
            var result = await _carRepository.GetAllCars();

            return Ok(result);
        }

        [HttpGet("available")]
        public async Task<IActionResult> GetAllAvailableCars()
        {
            var result = await _carRepository.GetAllAvailableCars();

            return Ok(result);
        }
        
        [HttpGet("rented")]
        public async Task<IActionResult> GetAllRentedCars()
        {
            var result = await _carRepository.GetAllRentedCars();

            return Ok(result);
        }


        [HttpPost("rent")]
        public async Task<IActionResult> RentCar([FromBody] RentCarModel rentCarModel)
        {
            var result = await _carRepository.RentCar(rentCarModel);

            if (result.Status == StatusType.Failed)
            {
                return StatusCode(StatusCodes.Status400BadRequest, result);
            }

            var report = (ReportResult) result.Message;

            File file = new File { Name = "protokol_wypozyczenie.pdf", ContentType = "application/pdf", Stream = report.MainStream, CreationTime = DateTime.Now, UpdateTime = DateTime.Now, CarId = rentCarModel.Car.Id, FileType = FileType.RENT };

            await _fileRepository.AddRentCarFile(file);

            return File(report.MainStream,"application/pdf", "protokol_wypozyczenie.pdf");
        }

        [HttpPost("return")]
        public async Task<IActionResult> ReturnCar([FromBody] ReturnCarModel returnCarModel)
        {
            var result = await _carRepository.ReturnCar(returnCarModel);

            if (result.Status == StatusType.Failed)
            {
                return StatusCode(StatusCodes.Status400BadRequest, result);
            }

            var report = (ReportResult)result.Message;

            File file = new File { Name = "protokol_zwrot.pdf", ContentType = "application/pdf", Stream = report.MainStream, CreationTime = DateTime.Now, UpdateTime = DateTime.Now, CarId = returnCarModel.Car.Id, FileType = FileType.RETURN };

            await _fileRepository.AddReturnCarFile(file);

            return File(report.MainStream, "application/pdf", "protokol_zwrot.pdf");
        }
    }
}
