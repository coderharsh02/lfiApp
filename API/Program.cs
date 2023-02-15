using System.Text;
using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add DbContext service to the container and configure it to use Sqlite so that it can be used thoroughout the program. 
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Add Cors service to the container.
builder.Services.AddCors();

// creating interface for service is useful when we want to test the service and is a good practice.
builder.Services.AddScoped<ITokenService, TokenService>();

// Add Authentication service to the container that uses JwtBearerDefaults.AuthenticationScheme having few options.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters
    {
        // ValidateIssuerSigningKey is used to validate the signature of the token.
        ValidateIssuerSigningKey = true,
        
        // IssuerSigningKey store the key that is used to sign the token.
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey"])),
        
        ValidateIssuer = false,

        ValidateAudience = false
    };
});

// app is the object that will be used to configure the request pipeline.
var app = builder.Build();

// app.UseCors() is used to allow cross-origin requests.
app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

// First we need to use authentication and then authorization.

// UseAuthentication() authenticates if the user is valid or not.
app.UseAuthentication();

// UseAuthorization() authorizes if the user is allowed to access the resource or not.
app.UseAuthorization();

// Configure the HTTP request pipeline.
app.MapControllers();

app.Run();
