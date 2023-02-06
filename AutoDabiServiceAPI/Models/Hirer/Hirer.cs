using System;
using System.ComponentModel.DataAnnotations;

namespace AutoDabiServiceAPI.Models
{
    public class Hirer
    {
        public Guid Id { get; set; }
        [StringLength(50, ErrorMessage = "Value for {0} must cannot be more than {1}")]
        public string Name { get; set; }
        [StringLength(50, ErrorMessage = "Value for {0} must cannot be more than {1}")]
        public string LastName { get; set; }
        public string Signature { get; set; }
    }
}