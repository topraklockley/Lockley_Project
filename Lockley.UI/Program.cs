using Lockley.BL;
using Lockley.DAL.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<SQLContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("CS1"));
}); // LC 101003

builder.Services.AddScoped(typeof(IRepository<>), typeof(SQLRepository<>));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
.AddCookie(cookieOptions =>
{
    cookieOptions.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    cookieOptions.SlidingExpiration = true;
    cookieOptions.LoginPath = "/login";
    cookieOptions.LogoutPath = "/logout";
    cookieOptions.AccessDeniedPath = "/";
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireAssertion(context => context.User.Identity.AuthenticationType == "AdminAuthorization");
    });
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseStatusCodePagesWithRedirects("error/{0}");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(name: "areas", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
