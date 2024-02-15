using InternKYC.DTOs.Requests;
using InternKYC.DTOs.Responses;

namespace InternKYC.Services.OTPDetailService
{
    public class OTPDetailService : IOTPDetailService
    {
        //variable to store application db context
        private readonly ApplicationDbContext DbContext;

        public OTPDetailService(ApplicationDbContext applicationDbContext)
        {
            //get db context through DI
            DbContext = applicationDbContext;
        }

        public String GenerateOTP()
        {
            // Generate and return a random OTP
            Random random = new Random();
            String otpCode = random.Next(10000, 99999).ToString();
            return otpCode;
        }

        public bool VerifyOTP(string mobile_number, string otp)
        {
            var storedOtp = DbContext.OTPdetails
                                .Where(mn => mn.mobile_number == mobile_number)
                                .Select(mn => mn.otp)
                                .FirstOrDefault();

            bool isOtpValid = !string.IsNullOrEmpty(storedOtp) && otp == storedOtp;

            return isOtpValid;

            throw new NotImplementedException();
        }

        
    }
}

