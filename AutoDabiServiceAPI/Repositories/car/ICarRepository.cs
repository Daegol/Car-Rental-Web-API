using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using AutoDabiServiceAPI.DTOs;
using AutoDabiServiceAPI.DTOs.UserDtos;
using AutoDabiServiceAPI.Models;
using AutoDabiServiceAPI.Models.Rent;

namespace AutoDabiServiceAPI.Repositories
{
    public interface ICarRepository
    {
        public Task<IEnumerable<Car>> GetAllCars();
        public Task<IEnumerable<Car>> GetAllAvailableCars();
        public Task<IEnumerable<Car>> GetAllRentedCars();
        public Task<ResultInfo> RentCar(RentCarModel rentCarModel);
        public Task<ResultInfo> ReturnCar(ReturnCarModel returnCarModel);
    }
}
