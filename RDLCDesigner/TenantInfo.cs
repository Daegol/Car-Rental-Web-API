using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RDLCDesigner
{
    public class TenantInfo
    {
        public string Tenant { get; set; }
        public string Address { get; set; }
        public string NipOrPesel { get; set; }
        public string RegonOrDocumentId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string HirerFullName { get; set; }
    }
}
