using System.ComponentModel.DataAnnotations;

namespace InternKYC.DTOs
{
    public class OTPDetailDTO
    {
        [Required]
        public string mobile_number { get; set; }

        [Required]
        public string otp { get; set; }
    }
}
