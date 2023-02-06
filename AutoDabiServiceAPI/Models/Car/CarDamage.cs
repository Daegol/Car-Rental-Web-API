using System;
using System.ComponentModel.DataAnnotations;

namespace AutoDabiServiceAPI.Models
{
    public class CarDamage
    {
        public Guid Id { get; set; }
        [Required]
        public CarDamagePart CarDamagePart { get; set; }
        [Required]
        public CarDamageType CarDamageType { get; set; }
        [StringLength(300, ErrorMessage = "Value for {0} must cannot be more than {1}")]
        public string Comments { get; set; }
        public string Image { get; set; }
        public Car Car { get; set; }
    }
}