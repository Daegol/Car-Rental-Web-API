using System;
using System.ComponentModel.DataAnnotations;

namespace AutoDabiServiceAPI.Models
{
    public class File
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Value for {0} must cannot be more than {1}")]
        public string Name { get; set; }
        [Required]
        public byte[] Stream { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Value for {0} must cannot be more than {1}")]
        public string ContentType { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public FileType FileType { get; set; }
        public Guid CarId { get; set; }
        [StringLength(100, ErrorMessage = "Value for {0} must cannot be more than {1}")]
        public string CarName { get; set; }

        public void setCarName(Car car)
        {
            CarName = car.Number + " " + car.Brand + " " + car.Model + " " + car.Year;
        }
    }

    public enum FileType
    {
        RENT,
        RETURN
    }
}
