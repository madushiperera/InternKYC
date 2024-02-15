using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InternKYC.DTOs.Requests
{
    public class KYCFormRequest
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public string title { get; set; }

        [Required]
        public string full_name { get; set; }

        [Required]
        public string nic_number { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string nationality { get; set; }

        [Required]
        public string mobile_number { get; set; }

        [Required]
        public string nic_front_image { get; set; }

        [Required]
        public string nic_rear_image { get; set; }

        [Required]
        public string selfie_image { get; set; }




    }
}
