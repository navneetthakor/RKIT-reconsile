//creating builder object 
using WebApplication1;
using NLog.Web;
using NLog;

var builder = WebApplication.CreateBuilder(args);

// Set the Global Diagnostics Context (GDC) for LogDirectory
var logDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
GlobalDiagnosticsContext.Set("LogDirectory", logDirectory);

// Automatically load NLog configuration from the "nlog.config" file
builder.Logging.ClearProviders().AddNLog("nlog.config");

Startup startup = new Startup(builder.Configuration);


startup.ConfigureServices(builder.Services);

var app = builder.Build();

startup.Configure(app, builder.Environment);

app.MapGet("/", () => "Hello World!");

app.Run();
