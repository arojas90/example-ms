

using Microsoft.Extensions.Logging.Console;
using System.Globalization;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using MediatR;
using System.Reflection;

public class Startup
{
    protected IConfiguration? Configuration { get; private set; }

    protected IHealthChecksBuilder? HealthChecksBuilder { get; private set; }

    public void RunApplication(string[] args)
    {
        WebApplicationBuilder webApplicationBuilder = WebApplication.CreateBuilder(args);
        webApplicationBuilder.Logging.ClearProviders();
        webApplicationBuilder.Logging.AddSimpleConsole(delegate (SimpleConsoleFormatterOptions options)
        {
            options.IncludeScopes = true;
            options.TimestampFormat = "yyyy-MM-dd'T'HH:mm:ss";
        });
        Configuration = webApplicationBuilder.Configuration;
        ConfigureServices(webApplicationBuilder.Services);
        WebApplication webApplication = webApplicationBuilder.Build();
        ConfigureApp(webApplication);
        webApplication.Run();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
        HealthChecksBuilder = services.AddHealthChecks();
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddControllers();
        services.AddHttpContextAccessor();
    }

    public void ConfigureApp(WebApplication app)
    {
        if (app != null)
        {
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("es-Cl");
            app.UseHttpsRedirection();
            app.UseRouting();
            app.MapHealthChecks("/health", new HealthCheckOptions
            {
                ResultStatusCodes =
                {
                    [HealthStatus.Healthy] = StatusCodes.Status200OK,
                    [HealthStatus.Degraded] = StatusCodes.Status500InternalServerError,
                    [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
                },
                ResponseWriter = HealthCheckUtil.HealthChecksResponseWriter
            });
            app.MapControllers();
        }
    }
}