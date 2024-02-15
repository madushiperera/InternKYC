using InternKYC.DTOs.Requests;
using InternKYC.DTOs.Responses;

namespace InternKYC.Services.KYCFormService
{
    public interface IKYCFormService
    {
        BaseResponse SubmitKYCForm(KYCFormRequest request);
    }
}
