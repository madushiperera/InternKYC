using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InternKYC.DTOs.Requests
{
    public class CreateOTPRequest
    {

        [Required]
        public string mobile_number { get; set; }

    }
}
