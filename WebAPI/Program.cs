using System.Globalization;
using Application;
using Application.Commons;
using Application.Commons.DataAccess;
using Application.Users.Features.CreateUser.Services.ImageService;
using Application.Users.Features.CreateUser.Services.TokenService;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebAPI.Extensions;
using WebAPI.Filters;
using WebAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<DevExcHandlerMiddleware>();
builder.Services.AddTransient<ProdExcHandlerMiddleware>();
builder.Services.AddHealthChecks();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresqlDocker")));
builder.Services.AddDbContext<HomederContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresqlDocker")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
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

builder.Services.AddLocalization();
builder.Services.Configure<RequestLocalizationOptions>(
    options =>
    {
        var supportedCultures = new List<CultureInfo>
        {
            new("en-US"),
            new("ru-RU"),
            new("pl-PL"),
            new("et-EE")
        };

        options.DefaultRequestCulture = new RequestCulture(culture: "en-US", uiCulture: "en-US");
        options.SupportedCultures = supportedCultures;
        options.SupportedUICultures = supportedCultures;
    }
);

builder.Services.AddSwaggerDocumentation();

var app = builder.Build();

app.UseAuthentication();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerDocumentation();
}

app.MapHealthChecks("/health-check");

app.UseHttpsRedirection();

app.UseAuthorization();

var localizeOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(localizeOptions.Value);

if (app.Environment.IsDevelopment())
{
    app.UseMiddleware<DevExcHandlerMiddleware>();
}

if (app.Environment.IsProduction())
{
    app.UseMiddleware<ProdExcHandlerMiddleware>();
}

app.MapControllers();

app.Run();