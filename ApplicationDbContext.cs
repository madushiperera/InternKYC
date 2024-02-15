using InternKYC.Models;
using Microsoft.EntityFrameworkCore;

namespace InternKYC
{
    public class ApplicationDbContext : DbContext
    {
        //constructors
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 

        }

        //add models to database context
        public virtual DbSet<OTPdetailModel> OTPdetails { get; set;}
        public virtual DbSet<KYCFormModel> KYCForms { get; set; }
    }
}
