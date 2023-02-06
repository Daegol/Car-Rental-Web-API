using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoDabiServiceAPI.Models.Protocol
{
    public class Protocol
    {
        public string Date { get; set; }
        public string User { get; set; }
        public string Place { get; set; }
        public string Time { get; set; }
        public Car Car { get; set; }
        public bool IsClearInside { get; set; }
        public bool IsClearOutside { get; set; }
    }
}
