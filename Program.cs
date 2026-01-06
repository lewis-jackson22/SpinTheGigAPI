using Microsoft.EntityFrameworkCore;
using SpinTheGig.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy
            .WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Register DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Read environment variable to decide if Swagger should be enabled
var enableSwagger = builder.Configuration.GetValue<bool>("EnableSwagger");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() && enableSwagger)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// CORS must be before MapControllers
app.UseCors("AllowAngular");

app.UseAuthorization();

app.MapControllers();

app.Run();
