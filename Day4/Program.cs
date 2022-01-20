using Day4;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRouting();
app.UseCustomMiddleware();

app.MapGet("/", () =>"Hello World123467!");
app.Run();
