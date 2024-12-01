using Microsoft.EntityFrameworkCore;
using Payment.API.Context;
using Payment.Services;
using PaymentShared.Interfaces;
using PaymentShared.Settings;

var builder = WebApplication.CreateBuilder(args);



var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));


// Register interface and classes
builder.Services.AddScoped<IPayment, PaymentService>();


var appSettingsSection = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppMgtSettingModel>(appSettingsSection);

var appSettings = appSettingsSection.Get<AppMgtSettingModel>();
AppMgtSetting.ConnectionString = appSettings.ConnectionString;


// Add services to the container.



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



app.UseAuthorization();

app.MapControllers();

app.Run();
