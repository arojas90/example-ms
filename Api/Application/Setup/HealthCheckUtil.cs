using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Diagnostics.HealthChecks;

public static class HealthCheckUtil
{
    public static Task HealthChecksResponseWriter(HttpContext context, HealthReport result)
    {
        if(context == null || result == null)
        {
            return Task.CompletedTask;
        }

        context.Response.ContentType = "application/json";

        var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
        options.Converters.Add(new JsonStringEnumConverter());

        var json = JsonSerializer.Serialize(new
        {
            checks = result.Entries,
            status = result.Status.ToString()
        }, options);

        return context.Response.WriteAsync(json);
    }
}