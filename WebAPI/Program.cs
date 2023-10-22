using Application;
using Application.Commons;
using Application.Users.Features.CreateUser.Services.ImageService;
using Application.Users.Features.CreateUser.Services.TokenService;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using WebAPI.ActionFilters;
using WebAPI.Extensions;
using WebAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<GlobalExceptionHandlerMiddleware>();
builder.Services.AddHealthChecks();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresqlDocker")));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

builder.Services.AddScoped<InputActionFilter>();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

builder.Services.AddAutoMapper(typeof(DependencyInjection).Assembly);

var authSetting = new AuthSetting();
builder.Configuration.GetSection(nameof(authSetting)).Bind(authSetting);
builder.Services.Configure<AuthSetting>(builder.Configuration.GetSection(nameof(authSetting)));
builder.Services.AddAuthenticationConfigs(authSetting);

builder.Services.AddSingleton<IImageService, ImageService>();
builder.Services.AddSingleton<ITokenService, TokenService>();


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

app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

app.MapControllers();

app.Run();
