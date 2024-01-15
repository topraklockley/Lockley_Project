using Lockley.BL;
using Lockley.DAL.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<SQLContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CS1"));
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(SQLRepository<>));

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "allowedOrigins", policy =>
    {
        policy.WithOrigins("http://localhost:5196")
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "http://localhost:5218",
        ValidAudience = "moderators",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("AuthorizationKey"))
    };
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("allowedOrigins");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
