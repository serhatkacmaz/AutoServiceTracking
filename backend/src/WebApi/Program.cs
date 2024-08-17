using AutoServiceTracking.Shared.Extensions;
using AutoServiceTracking.Shared.Security.Jwt;
using AutoServiceTracking.Shared.Settings;
using Azure.Core;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Repository;
using Service;
using Service.Validations;
using WebApi.Infrastructure.Filters;
using WebApi.Infrastructure.Middelwares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//FluentValidation - Filter
builder.Services.AddControllers(options => options.Filters.Add(new ValidateFilterAttribute())).AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<CreateUserDtoValidator>());
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddRepositoryLayerServices(builder.Configuration);
builder.Services.AddServiceLayerServices();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthServices(builder.Configuration);

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

app.UseGlobalException();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
