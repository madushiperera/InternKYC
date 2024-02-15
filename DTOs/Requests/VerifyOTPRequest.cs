using System.ComponentModel.DataAnnotations;

namespace InternKYC.DTOs.Requests
{
    public class VerifyOTPRequest
    {
        [Required]
        public string otp { get; set; }

        public string mobile_number { get; set; }
    }
}
