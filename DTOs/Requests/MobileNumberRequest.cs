using System.ComponentModel.DataAnnotations;

namespace InternKYC.DTOs.Requests
{
    public class MobileNumberRequest
    {
        [Required]
        public string mobile_number { get; set; }
    }
}
