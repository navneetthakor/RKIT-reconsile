

//creating builder object 
using Final_Demo_AvanceCSharp;

var builder = WebApplication.CreateBuilder(args);

Startup startup = new Startup(builder.Configuration);

startup.ConfigureServices(builder.Services);

var app = builder.Build();

startup.Configure(app, builder.Environment);

app.MapGet("/", () => "Hello World!");

app.Run();
