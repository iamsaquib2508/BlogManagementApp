using BlogManager.Data;
using Microsoft.EntityFrameworkCore;

using AutoMapper;
using BlogManager.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();

// Add EF Core with SQLite
builder.Services.AddDbContext<BlogContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(typeof(BlogProfile));  // register AutoMapper

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200") // Angular dev server
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Build app
var app = builder.Build();

app.UseCors("AllowAngularApp");

// Middleware
app.UseHttpsRedirection();
app.UseAuthorization();

// Map controllers
app.MapControllers();

app.Run();
