using InternKYC;
using InternKYC.Services.KYCDetailService;
using InternKYC.Services.KYCFormService;
using InternKYC.Services.OTPDetailService;
using InternKYC.Services.OTPService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add Application Db Context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

//register custom services
builder.Services.AddScoped<IOTPDetailService, OTPDetailService>();
builder.Services.AddScoped<IKYCDetailService, KYCDetailService>();
builder.Services.AddScoped<IKYCFormService, KYCFormService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
