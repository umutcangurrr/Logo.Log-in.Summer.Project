using Application.Logo.Business.Interface;
using Application.Logo.Business.Services;
using AutoMapper;


var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddScoped<IMonitoringService, MonitoringService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();