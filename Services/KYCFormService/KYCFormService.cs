using InternKYC.DTOs.Requests;
using InternKYC.DTOs.Responses;
using InternKYC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Linq;

namespace InternKYC.Services.KYCFormService
{
    public class KYCFormService : IKYCFormService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IWebHostEnvironment _environment;

        public KYCFormService(ApplicationDbContext dbContext, IWebHostEnvironment environment)
        {
            _dbContext = dbContext;
            _environment = environment;
        }

  
        public BaseResponse SubmitKYCForm(KYCFormRequest request)
        {
            BaseResponse response;
            try
            {
                // Convert base64 encoded images to byte arrays
                byte[] selfie_Image = Convert.FromBase64String(request.selfie_image);
                byte[] nicFront_Image = Convert.FromBase64String(request.nic_front_image);
                byte[] nicRear_Image = Convert.FromBase64String(request.nic_rear_image);

                // Save images to server and get file paths
                string selfieImageurl = SaveBase64Image(selfie_Image, "selfie_image");
                string nicFrontImageurl = SaveBase64Image(nicFront_Image, "nic_front_image");
                string nicRearImageurl = SaveBase64Image(nicRear_Image, "nic_rear_image");

                KYCFormModel newKYCForm = new KYCFormModel
                {
                    title = request.title,
                    full_name = request.full_name,
                    mobile_number = request.mobile_number,
                    email = request.email,
                    nic_number = request.nic_number,
                    nationality = request.nationality,
                    selfie_image = selfieImageurl,
                    nic_front_image = nicFrontImageurl,
                    nic_rear_image= nicRearImageurl
                };

                using (_dbContext)
                {
                    _dbContext.Add(newKYCForm);
                    _dbContext.SaveChanges();
                }

                response = new BaseResponse
                {
                    status_code = StatusCodes.Status200OK,
                    data = new { message = "Successfully registered to KYC " }
                };
            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = "Internal Server Error:" + ex.Message }
                };
            }

            return response;
        }

        private string SaveBase64Image(byte[] imageBytes, string prefix)
        {
            if (imageBytes == null || imageBytes.Length == 0)
            {
                return null;
            }

            try
            {
                string fileName = $"{prefix}_{Guid.NewGuid()}.jpg";
                string uploadFolder = Path.Combine(_environment.WebRootPath, "Upload");

                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }

                string filePath = Path.Combine(uploadFolder, fileName);

                using (FileStream filestream = System.IO.File.Create(filePath))
                {
                    filestream.Write(imageBytes, 0, imageBytes.Length);
                }

                string relativePath = "\\Upload\\" + fileName;
                return relativePath;

            }

            catch (Exception ex)
            {
                throw new Exception($"Error saving {prefix} image: {ex.Message}");
            }
            throw new NotImplementedException();
        }
    }
}


        
        
