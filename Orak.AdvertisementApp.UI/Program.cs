using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Orak.AdvertisementApp.Business.DependencyResolvers.Microsoft;
using Orak.AdvertisementApp.Business.Helpers;
using Orak.AdvertisementApp.UI.Mappings.AutoMapper;
using Orak.AdvertisementApp.UI.Models;
using Orak.AdvertisementApp.UI.ValidationRules;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDependencies(builder.Configuration);
builder.Services.AddTransient<IValidator<AppUserCreateModel>, AppUserCreateModelValidator>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt=>
{
    opt.Cookie.Name = "KuariCookie";
    opt.Cookie.HttpOnly = true; // client side splitlerden korunmak i�in
    opt.Cookie.SameSite = SameSiteMode.Strict; // Cookie'yi  payla��ma kapatmak i�in.
    opt.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest; // ilgili istek bize http clientten gelirse http'de, https'den gelirse https2de ilgili cookiemiz �al��ss�n 
    opt.ExpireTimeSpan = TimeSpan.FromDays(20); // ilgili cookienin hayatta kalaca�� zaman� belirttik.
    opt.LoginPath = new PathString("/Account/SignIn"); // login path
    opt.LogoutPath = new PathString("/Account/LogOut");
    opt.AccessDeniedPath = new PathString("/Account/AccessDenied");
});

builder.Services.AddControllersWithViews();
var profiles = ProfileHelper.GetProfiles();
profiles.Add(new AppUserCreateModelProfile());

var configuration = new MapperConfiguration(opt =>
{
    opt.AddProfiles(profiles);
});
var mapper = configuration.CreateMapper();
builder.Services.AddSingleton(mapper);




var app = builder.Build();
app.UseStaticFiles();
app.MapDefaultControllerRoute();
app.UseAuthentication();
app.UseAuthorization();

app.Run();
