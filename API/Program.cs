using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Register our data context
builder.Services.AddDbContext<DataContext>(options =>
{
    // appsettings.development.json - bol olvassa ki
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Middleware start
// Configure the HTTP request pipeline.
// Maps controllers
app.MapControllers();

// Middleware end

app.Run();
