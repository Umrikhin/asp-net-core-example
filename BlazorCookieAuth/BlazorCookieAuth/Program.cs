// ******
// ��� �������������� BLAZOR COOKIE (������)
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
// ��� �������������� BLAZOR COOKIE (�����)
// ******

using BlazorCookieAuth.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// ******
// ��� �������������� BLAZOR COOKIE (������)
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme) .AddCookie();
// ��� �������������� BLAZOR COOKIE (�����)
// ******

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

// ******
// ��� �������������� BLAZOR COOKIE (������)
// ��: https://github.com/aspnet/Blazor/issues/1554
// HttpContextAccessor
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<HttpContextAccessor>();
builder.Services.AddHttpClient();
builder.Services.AddScoped<HttpClient>();
// ��� �������������� BLAZOR COOKIE (�����)
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
// ��� �������������� BLAZOR COOKIE (������)
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();
app.UseAuthentication();
// ��� �������������� BLAZOR COOKIE (�����)
// ******

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

// ******
// ��� �������������� BLAZOR COOKIE (������)
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
// ��� �������������� BLAZOR COOKIE (������)
// ******

app.Run();
