using Microsoft.AspNetCore.Diagnostics;
using System.Net;

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
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddProductRepo();
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage(
                   new DeveloperExceptionPageOptions
                   {
                       SourceCodeLineCount = 10
                   });
            }
            else
            {
                app.UseExceptionHandler(
                   options =>
                   {
                       options.Run(
                           async context =>
                           {
                               context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                               var ex = context.Features.Get<IExceptionHandlerFeature>();
                               if (ex != null)
                               {
                                   await context.Response.WriteAsync(ex.Error.Message);
                               }
                           }
                    );
                   });






            }

            //calling 
            //app.UseRouting();
            //is not necessory 


            // Redirect HTTP requests to HTTPS
            app.UseHttpsRedirection();

            // Map incoming requests to controller actions
            app.MapControllers();

            // End the request pipeline 
            app.Run();
        }
    }
}
