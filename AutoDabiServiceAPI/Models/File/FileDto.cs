using System;
using System.ComponentModel.DataAnnotations;

namespace AutoDabiServiceAPI.Models
{
    public class FileDto
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Value for {0} must cannot be more than {1}")]
        public string Name { get; set; }
        [Required]
        public string Stream { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Value for {0} must cannot be more than {1}")]
        public string ContentType { get; set; }
        public string CreationTime { get; set; }
        public string UpdateTime { get; set; }
        public FileType FileType { get; set; }
        public Guid CarId { get; set; }
        public string CarName { get; set; }

    }

}
