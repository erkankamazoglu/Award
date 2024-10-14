using AwardEntity.Base;
using AwardService;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Utility.Http;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
{
    option.Cookie.Name = "AwardAuthCookie";
    option.LoginPath = "/Login/Index";
    option.LogoutPath = "/Login/Index";
    option.AccessDeniedPath = "/Login/Index";
});

builder.Services.AddDbContext<ModelContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<AwardService.AwardService>();
builder.Services.AddScoped<UserAwardService>();
builder.Services.AddScoped<CategoryService>();

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
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "node_modules")),
    RequestPath = "/vendor"
}); 

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

// Configure HttpContextHelper
HttpContextHelper.Configure(app.Services.GetRequiredService<IHttpContextAccessor>());
app.Run();
