using System.Text.Json;
namespace Day4;

public class CustomMiddleware
{
    private readonly RequestDelegate _next;

    public CustomMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var requestData = new 
        {
            Scheme = context.Request.Scheme,
            Host = context.Request.Host.ToString(),
            Path = context.Request.Path.ToString(),
            QueryString = context.Request.QueryString.ToString(),
        };


     using (StreamWriter writer = File.AppendText("file.txt"))
        {
       var data = JsonSerializer.Serialize(requestData);
           writer.WriteLine(data);
        }
            await _next(context);

    }
}

public static class CustomMiddlewareExtensions
{
    public static IApplicationBuilder UseCustomMiddleware(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<CustomMiddleware>();
    }
}