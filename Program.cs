using ComptrollerApi.Data;
using ComptrollerApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Register the DbContext with SQLite
builder.Services.AddDbContext<TaxReportDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("TaxReportDbConnection")));

// Register the repository as a singleton or scoped service
builder.Services.AddScoped<TaxReportRepository>();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
