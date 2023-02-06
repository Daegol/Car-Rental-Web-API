using AutoDabiServiceAPI.Models.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoDabiServiceAPI.Models.Rent
{
    public class RentCarModel
    {
        public string ContractNumber { get; set; }
        public string StartDate { get; set; }
        public Car Car { get; set; }
        public List<Driver> Driver { get; set; }
        public Hirer Hirer { get; set; }
        public TenantBusiness TenantBusiness { get; set; }
        public TenantPrivate TenantPrivate { get; set; }
        public string HirerSignature { get; set; }
        public string TenantSignature { get; set; }
        public string Place { get; set; }
        public bool isCleanInside { get; set; }
        public bool isCleanOutside { get; set; }
        public List<string> DriverSignature { get; set; }
        public HandedOverWithCar HandedOverWithCar { get; set; }
    }
}
