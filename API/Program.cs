using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();


// Add DbContext service to the container and configure it to use Sqlite so that it can be used thoroughout the program. 
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// app is the object that will be used to configure the request pipeline.
var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapControllers();

app.Run();
