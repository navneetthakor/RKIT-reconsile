//creating builder object 
using WebApplication1;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

// Set the Global Diagnostics Context (GDC) for LogDirectory
var logDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
NLog.GlobalDiagnosticsContext.Set("LogDirectory", logDirectory);

// Automatically load NLog configuration from the "nlog.config" file
builder.Logging.ClearProviders().AddNLog("nlog.config");

Startup startup = new Startup(builder.Configuration);

// adding services in dependecy injection container
startup.ConfigureServices(builder.Services);

// building app
var app = builder.Build();

// setting up0p configuration (middleware pipeline, routing setup)
startup.Configure(app, builder.Environment);

app.MapGet("/", () => "Hello World!");

app.Run();
