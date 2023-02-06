using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoDabiServiceAPI.Models.Protocol
{
    public class HandedOverWithCar
    {
        public bool Anten { get; set; }
        public bool RegistrationCertificate { get; set; }
        public bool Oc { get; set; }
        public bool Radio { get; set; }
        public string RadioContent { get; set; }
        public bool Hubcup { get; set; }
        public string HubcupAmount { get; set; }
        public bool TireFront { get; set; }
        public bool TireBack { get; set; }
        public bool SpareTires { get; set; }
        public bool FireExtinguisher { get; set; }
        public bool Triangle { get; set; }
        public bool Jack { get; set; }
        public bool Others { get; set; }
        public string OthersContent { get; set; }
    }
}
