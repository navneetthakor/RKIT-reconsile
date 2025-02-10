using Microsoft.AspNetCore.Diagnostics;
using Microsoft.OpenApi.Models;
using Nlog.Web;
using System.Net;
using WebApplication1.Utilitlies;

namespace WebApplication1
{
    /// <summary>
    /// Class responsible for configuring the application during startup. 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Configuration property containing the application's configuration
        /// </summary>
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddTransient<IDatabaseService, DatabaseService>();
            services.AddSwaggerGen(c =>
            {
                // Add API key definition to Swagger
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Description = "Provide the API key in the header"
                });

                // Add security requirement to require the API key
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                 {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                 });
            });

            // nlogger related setup
            var logPath = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
            NLog.GlobalDiagnosticsContext.Set("LogDirectory", logPath);

        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

            }

            // nlogger middleware
            app.UseNLog();
            
            //calling 
            app.UseRouting();
            //is not necessory 

            app.UseMiddleware<JwtMiddleware>();

            app.MapGet("/", () => "Hello World!");

            // Redirect HTTP requests to HTTPS
            app.UseHttpsRedirection();

            // Map incoming requests to controller actions
            app.MapControllers();

            // End the request pipeline 
            app.Run();
        }
    }
}
