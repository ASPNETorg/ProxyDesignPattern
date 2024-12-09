using Microsoft.EntityFrameworkCore;
using S11.ProxyDesignPattern.Sample01.ApplicationServices.Convertor.Frameworks.Contracts;
using S11.ProxyDesignPattern.Sample01.ApplicationServices.Convertor.Services;
using S11.ProxyDesignPattern.Sample01.ApplicationServices.Dtos.Person;
using S11.ProxyDesignPattern.Sample01.ApplicationServices.Frameworks.Contracts;
using S11.ProxyDesignPattern.Sample01.ApplicationServices.Services;
using S11.ProxyDesignPattern.Sample01.Models;
using S11.ProxyDesignPattern.Sample01.Models.DomainModels;
using S11.ProxyDesignPattern.Sample01.Models.Frameworks.Contracts;
using S11.ProxyDesignPattern.Sample01.Models.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ProjectDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default") ??
    throw new InvalidOperationException("Connection string 'Default' not found.")));
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IConvertor<PostPersonDto, Person>, PersonConvertor>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
