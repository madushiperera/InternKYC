using InternKYC.DTOs.Requests;
using InternKYC.DTOs.Responses;
using InternKYC.Services.KYCFormService;
using InternKYC.Services.OTPService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InternKYC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KYCController : ControllerBase
    {
        private readonly IKYCFormService _kycFormService;

        public KYCController(IKYCFormService kycFormService)
        {
            _kycFormService = kycFormService;
        }

        [HttpPost("submit")]
        public BaseResponse SubmitKYCForm(KYCFormRequest request)
        {
            return _kycFormService.SubmitKYCForm(request);
        }
        /*public async Task<IActionResult> SubmitKYCForm([FromForm] KYCFormRequest request,
                                                       IFormFile nicFrontImage,
                                                       IFormFile nicBackImage,
                                                       IFormFile selfieImage)
        {
            if (request == null || nicFrontImage == null || nicBackImage == null || selfieImage == null)
            {
                return BadRequest("Form details and images are required.");
            }

            var response =  _kycFormService.KYCForm(request, nicFrontImage, nicBackImage, selfieImage);

            if (response.status_code == StatusCodes.Status200OK)
            {
                return Ok(response.data);
            }
            else
            {
                return StatusCode(response.status_code, response.data);
            }
        }*/
    }
}
