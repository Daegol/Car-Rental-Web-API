using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoDabiServiceAPI.Models
{
    public class Car
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Value for {0} must cannot be more than {1}")]
        public string Number { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Value for {0} must cannot be more than {1}")]
        public string Brand { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Value for {0} must cannot be more than {1}")]
        public string Model { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Value for {0} must cannot be more than {1}")]
        public string FuelType { get; set; }
        [Range(0, 1000000000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Mileage { get; set; } = 0;
        [Required]
        [StringLength(50, ErrorMessage = "Value for {0} must cannot be more than {1}")]
        public string GearBoxType { get; set; }
        [Required]
        [Range(1900, 2100, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Year { get; set; }
        [Range(0.0, 1.0, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        [Display(Name = "Fuel Content")]
        public double FuelContent { get; set; } = 0.0;
        public bool Available { get; set; } = false;
        public ICollection<CarDamage> CarDamages { get; set; } = null;
    }
}