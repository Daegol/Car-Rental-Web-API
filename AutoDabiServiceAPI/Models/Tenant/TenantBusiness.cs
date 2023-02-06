using System;
using System.ComponentModel.DataAnnotations;

namespace AutoDabiServiceAPI.Models
{
    public class TenantBusiness
    {
        public Guid Id { get; set; }
        [StringLength(50, ErrorMessage = "Value for {0} must cannot be more than {1}")]
        public string Name { get; set; }
        [StringLength(50, ErrorMessage = "Value for {0} must cannot be more than {1}")]
        public string Nip { get; set; }
        [StringLength(50, ErrorMessage = "Value for {0} must cannot be more than {1}")]
        public string Regon { get; set; }
        [StringLength(50, ErrorMessage = "Value for {0} must cannot be more than {1}")]
        [Display(Name = "Represented by")]
        public string RepresentedBy { get; set; }
        [StringLength(50, ErrorMessage = "Value for {0} must cannot be more than {1}")]
        [Display(Name = "Correspondence Address")]
        public string CorrespondenceAddresss { get; set; }
        [StringLength(50, ErrorMessage = "Value for {0} must cannot be more than {1}")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [StringLength(50, ErrorMessage = "Value for {0} must cannot be more than {1}")]
        public string Email { get; set; }
        public string Signature { get; set; }
    }
}