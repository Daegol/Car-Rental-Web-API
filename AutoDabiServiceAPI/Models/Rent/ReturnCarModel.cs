using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoDabiServiceAPI.Models.Rent
{
    public class ReturnCarModel
    {
        public Car Car { get; set; }
        public string TenantSignature { get; set; }
        public string HirerSignature { get; set; }

    }
}
