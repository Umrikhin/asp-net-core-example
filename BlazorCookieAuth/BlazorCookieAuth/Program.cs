// ******
// Код аутентификации BLAZOR COOKIE (начало)
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
// Код аутентификации BLAZOR COOKIE (конец)
// ******

using BlazorCookieAuth.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// ******
// Код аутентификации BLAZOR COOKIE (начало)
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
// Код аутентификации BLAZOR COOKIE (конец)
// ******

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

// ******
// Код аутентификации BLAZOR COOKIE (начало)
// Из: https://github.com/aspnet/Blazor/issues/1554
// HttpContextAccessor
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<HttpContextAccessor>();
builder.Services.AddHttpClient();
builder.Services.AddScoped<HttpClient>();
// Код аутентификации BLAZOR COOKIE (конец)
// ******

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

// ******
// Код аутентификации BLAZOR COOKIE (начало)
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();
app.UseAuthentication();
// Код аутентификации BLAZOR COOKIE (конец)
// ******

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

// ******
// Код аутентификации BLAZOR COOKIE (начало)
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
// Код аутентификации BLAZOR COOKIE (начало)
// ******

app.Run();
