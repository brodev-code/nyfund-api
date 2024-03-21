using NyFund.Api.Panel;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", true);
builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true);
builder.Configuration.AddXmlFile($"App.{builder.Environment.EnvironmentName}.config", true, true);
builder.Configuration.AddEnvironmentVariables();

var startup = new Startup(builder.Configuration, builder.Environment);
startup.ConfigureServices(builder.Services);
var app = builder.Build();
startup.Configure(app);

app.Run();