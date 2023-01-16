using CerenaPayment.Data;
using CerenaPayment.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DataBase");

builder.Services.AddEntityFrameworkSqlServer().AddDbContext<Context>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<ITherapyRepository, TherapyRepository>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
