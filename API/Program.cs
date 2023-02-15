using System.Text;
using API.Data;
using API.Extensions;
using API.Interfaces;
using API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Moving application services to ApplicationServiceExtensions and using it here.
builder.Services.AddApplicationServices(builder.Configuration);

// Moving identity services to IdentityServiceExtensions and using it here.
builder.Services.AddIdentityServices(builder.Configuration);

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
