using InternKYC.DTOs.Requests;
using InternKYC.DTOs.Responses;
using InternKYC.Models;
using InternKYC.Services.KYCDetailService;
using InternKYC.Services.OTPDetailService;
using Microsoft.EntityFrameworkCore;

namespace InternKYC.Services.OTPService
{
    public class KYCDetailService : IKYCDetailService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IOTPDetailService oTPDetailService;

        public KYCDetailService(DbContextOptions<ApplicationDbContext> dbContextOptions, IOTPDetailService oTPDetailService)
        {
            dbContext = new ApplicationDbContext(dbContextOptions);
            this.oTPDetailService = oTPDetailService;
        }


        public BaseResponse MobileNumber(MobileNumberRequest request)
        {
            BaseResponse response = new BaseResponse();

            try
            {
                String generatedotp = oTPDetailService.GenerateOTP();

                var oTPDetailModel = new OTPdetailModel
                {
                    mobile_number = request.mobile_number,
                    otp = generatedotp
                };

                var db = dbContext.OTPdetails.FirstOrDefault(mn => mn.mobile_number == request.mobile_number);

                if (db != null)
                {
                    db.otp = generatedotp;
                }
                else
                {
                    dbContext.OTPdetails.Add(oTPDetailModel);
                }
                dbContext.SaveChanges();

                response.status_code = StatusCodes.Status200OK;
                response.data = new { message = "OTP successfully generated" };
            }
            catch (Exception ex)
            {
                response.status_code = StatusCodes.Status500InternalServerError;
                response.data = new { message = "Internal server error:" + ex.Message };
            }
            return response;
        }





        public BaseResponse VerifyOTP(VerifyOTPRequest request)
        {
            BaseResponse response = new BaseResponse();

            try
            {
                bool isotpvalid = oTPDetailService.VerifyOTP(request.mobile_number, request.otp);
                if (isotpvalid)
                {
                    response.status_code = StatusCodes.Status200OK;
                    response.data = new { message = "Valid OTP" };
                }
                else
                {
                    response.status_code = StatusCodes.Status400BadRequest;
                    response.data = new { message = "Invalid OTP" };
                }
                return response;
            }
            catch (Exception ex)
            {
                response.status_code = StatusCodes.Status500InternalServerError;
                response.data = new { message = "Internal server error:" + ex.Message };
            }
            return response;
        }
    }    
}
