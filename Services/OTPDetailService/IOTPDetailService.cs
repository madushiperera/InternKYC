using InternKYC.DTOs.Requests;
using InternKYC.DTOs.Responses;

namespace InternKYC.Services.OTPDetailService
{
    public interface IOTPDetailService
    {
        String GenerateOTP();

        bool VerifyOTP(String mobile_number, String otp);


    }
}
