using Core;

using Infrastructure;

using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Cosmos.Internal;
using Microsoft.Extensions.Options;

using Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddScoped<ICarService, CarService>()
    .AddScoped<IDataRepository<Car>, DataCarRepository>()
;


builder.Services.AddDbContextFactory<MyDbContext>(
   (IServiceProvider sp, DbContextOptionsBuilder opts) =>
   {
       opts.UseCosmos("https://localhost:8081/", "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==", nameof(MyDbContext), options =>
       {
           options.HttpClientFactory(() =>
           {
               HttpMessageHandler httpMessageHandler = new HttpClientHandler()
               {
                   ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
               };

               return new HttpClient(httpMessageHandler);
           });

           options.ConnectionMode(ConnectionMode.Gateway);
           //options.ConnectionMode(ConnectionMode.Gateway);
           //options.IdleTcpConnectionTimeout(TimeSpan.FromMinutes(1));
           //options.OpenTcpConnectionTimeout(TimeSpan.FromMinutes(1));
           //options.RequestTimeout(TimeSpan.FromMinutes(1));
       });

       opts.EnableSensitiveDataLogging(true);
   });
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
