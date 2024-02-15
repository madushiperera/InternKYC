using InternKYC.DTOs.Requests;
using InternKYC.DTOs.Responses;
using InternKYC.Services.KYCDetailService;
using InternKYC.Services.OTPDetailService;
using InternKYC.Services.OTPService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

namespace InternKYC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OTPDetailController : ControllerBase
    {
        private readonly IKYCDetailService KYCDetailService;

        //constructors
        public OTPDetailController(IKYCDetailService KYCDetailService)
        {
            this.KYCDetailService = KYCDetailService;
        }

        //endpoints
        [HttpPost("MobileNumber")]
        public BaseResponse MobileNumber(MobileNumberRequest request)
        {
            return KYCDetailService.MobileNumber(request);

        }
        
        [HttpPost("VerifyOTP")]
        public BaseResponse VerifyOTP(VerifyOTPRequest request) 
        {
            return KYCDetailService.VerifyOTP(request);
        }
    }
}
