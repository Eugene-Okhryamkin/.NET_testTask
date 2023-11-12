using DaDataTestService.Services;
using AutoMapper;

using DaData;
using DaData.Interfaces;
using DaData.Options;
using DaDataTestService.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));

var daDataOptions = new ApiClientOptions();
builder.Configuration.GetSection("DaDataSettings").Bind(daDataOptions);
builder.Services.Configure<ApiClientOptions>(builder.Configuration.GetSection("DaDataSettings"));

builder.Services.AddScoped<IDaDataApiClient>(_ => new ApiClient(daDataOptions.Token, daDataOptions.Secret));



builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IDaDataService, DaDataService>();

builder.Services.AddScoped<AddressRepository>();
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