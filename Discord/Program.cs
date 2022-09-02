using Discord;
using Discord.Context;
using Discord.Extensions;
using Discord.Options;
using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAntiforgery((options) =>
{
    options.Cookie.Name = ApplicationCookie.Antiforgery.Name;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.FormFieldName = "_anti-forgery";
    options.HeaderName = "x-anti-forgery";
});

builder.Services.AddOptions();
builder.Services.Configure<SiteOptions>(builder.Configuration.GetSection("Site"));
builder.Services.AddTransient((p) => p.GetRequiredService<IOptionsMonitor<SiteOptions>>().CurrentValue);
builder.Services.Configure<ApplicationInsightsServiceOptions>((p) => p.ApplicationVersion = "1");


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHsts((options) =>
{
    options.IncludeSubDomains = false;
    options.MaxAge = TimeSpan.FromDays(365);
    options.Preload = false;
});

builder.Services.AddDbContext<DataContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("Data"));
});

builder.Services.AddApplicationAuthentication(builder.Configuration);

var app = builder.Build();

var options = app.Services.GetRequiredService<IOptionsMonitor<SiteOptions>>();

app.UseCustomHttpHeaders(app.Environment, app.Configuration, options);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseIdentity(options.CurrentValue);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseCookiePolicy(new()
{
    HttpOnly = HttpOnlyPolicy.Always,
    Secure = CookieSecurePolicy.Always,
});


app.Run();
