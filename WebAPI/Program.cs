using Application;
using Application.Commons;
using Application.Commons.Services.TokenService;
using Application.Commons.Utilities;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecks();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresqlDocker")));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

builder.Services.AddAutoMapper(typeof(DependencyInjection).Assembly);

var authSetting = new AuthSetting();
builder.Configuration.GetSection(nameof(authSetting)).Bind(authSetting);
builder.Services.Configure<AuthSetting>(builder.Configuration.GetSection(nameof(authSetting)));

builder.Services.AddSingleton<IConverterUtility, ConverterUtility>();
builder.Services.AddSingleton<ITokenService, TokenService>();

builder.Services.AddAuthenticationConfigs(authSetting);

builder.Services.AddSwaggerConfigs();

var app = builder.Build();

app.UseAuthentication();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapHealthChecks("/health-check");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
