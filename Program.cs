using Microsoft.EntityFrameworkCore;
using TracePointAPI.Data;
// Railway deployment refresh - October 2026
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactPolicy", policy =>
    {
        policy.WithOrigins(
            "http://localhost:5173",
            "https://trace-point-six.vercel.app"
        )
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
builder.Services.AddControllers();

builder.Services.AddDbContext<TracePointDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("TracePointConnection"),
        ServerVersion.AutoDetect(
            builder.Configuration.GetConnectionString("TracePointConnection"))));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("ReactPolicy");

app.MapControllers();
app.Run();

public partial class Program
{
}