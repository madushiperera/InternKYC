using InternKYC.DTOs.Requests;
using InternKYC.DTOs.Responses;

namespace InternKYC.Services.KYCDetailService
{
    public interface IKYCDetailService
    {
        BaseResponse MobileNumber(MobileNumberRequest request);

        //BaseResponse GenerateOTP(VerifyOTPRequest request);

        BaseResponse VerifyOTP(VerifyOTPRequest request);   

    }
}
