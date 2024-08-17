using Microsoft.EntityFrameworkCore;
using UrlShortener.Application;
using UrlShortener.Application.Urls;
using UrlShortener.Data.EntityFrameworkCore;
using UrlShortener.Domain.Url;
using UrlShortener.EntityFrameworkCore.Urls;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.AllowAnyOrigin(/*"http://localhost:5173/"*/)
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

builder.Services.AddControllers();

builder.Services.AddDbContext<EfContext>(
        options => options.UseSqlServer("Data Source = MSI\\MSSQLSERVER01; Database = LocalDb; Trusted_Connection=True;TrustServerCertificate=True"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IUrlRepository, EfCoreUrlRepository>();

builder.Services.AddScoped<IUrlAppService, UrlAppService>();

// Configure domain services
builder.Services.AddScoped<UrlManager>();

var app = builder.Build();

app.UseCors("AllowSpecificOrigin");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
