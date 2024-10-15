using Entities;
using Microsoft.EntityFrameworkCore;
using MoneyCalculator.Mappings;
using MoneyCalculator.ServiceContracts;
using MoneyCalculator.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

// add services into IoC container

builder.Services.AddScoped<IMoneyService, MoneyService>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// database:
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

//app
var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}


app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
