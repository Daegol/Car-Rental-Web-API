using System;
using System.ComponentModel.DataAnnotations;

namespace AutoDabiServiceAPI.Models
{
    public class CarDamagePart
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Value for {0} must cannot be more than {1}")]
        public string Name { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Value for {0} must cannot be more than {1}")]
        public string Code { get; set; }
    }
}