/*
 Program.cs: Initialized the web host, set up any global configuration (such as environment),
 and told the application to use Startup.cs for further configuration.

 Startup.cs: Was responsible for the detailed setup, registering services, and defining the HTTP request pipeline through middleware.

 In .NET 6 and later, these responsibilities are combined into a more streamlined approach in a single Program.cs file.
 */

#region template code
//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.



//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();
#endregion

using DemoProject;
using Microsoft.AspNetCore.Hosting;

public class Program
{
    public static void Main(string[] args)
    {
        // Create a new WebApplicationBuilder instance
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        // Create a new instance of the Startup class, passing the application's configuration to it.
        Startup startup = new Startup(builder.Configuration);

        // Configuring Services
        startup.ConfigureServices(builder.Services);

        // Build the web application using the configured services
        WebApplication app = builder.Build();

        // Configure the application and its environment
        startup.Configure(app, builder.Environment);
    }
}
