using BlogManagementSystem.BL;
using BlogManagementSystem.Middleware;
using BlogManagementSystem.Models;
using BlogManagementSystem.Models.POCO;
using BlogManagementSystem.Services;
using NLog;
using NLog.Extensions.Logging;
using NLog.Web;
using ServiceStack.Data;
using ServiceStack.OrmLite;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        // Load NLog configuration from nlog.config
        LogManager.LoadConfiguration("nlog.config");
        Configuration = configuration;

        // Test log to check NLog configuration
        var logger = LogManager.GetCurrentClassLogger();
        logger.Info("NLog configuration loaded successfully.");
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        // Cors Configuration
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
        });

        services.AddControllers();
        services.AddControllers().AddNewtonsoftJson();
        services.AddControllers(options =>
        {
            // Add LogActionFilter globally to all actions
            options.Filters.Add<BlogManagementSystem.Filters.LogActionFilter>();
        });

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        // Configure ORM Lite
        services.AddSingleton<IDbConnectionFactory>(new OrmLiteConnectionFactory(
            Configuration.GetConnectionString("BlogDB"), MySqlDialect.Provider));

        // Configure Logging (NLog will handle logging internally)
        services.AddLogging(loggingBuilder =>
        {
            loggingBuilder.ClearProviders();
            loggingBuilder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
            loggingBuilder.AddNLog(Configuration);
        });

        // Configure Response Model
        services.AddTransient<IResponse,Response>();

        // Configure BLG01 Model
        services.AddTransient<IBLG01, BLG01>();

        // Configure BLConverter
        services.AddTransient<IBLConverter,BLConverter>();

        // Configure BLBlog
        services.AddTransient<IBLBLog,BLBlog>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();
        app.UseCors();
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseDeveloperExceptionPage();
        }

        // Ensure UseRouting is added before MapControllers
        app.UseRouting();

        app.UseAuthorization();

        // MapControllers should be called after UseRouting
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        // Ensure NLog resources are released on application exit
        app.ApplicationServices.GetRequiredService<IHostApplicationLifetime>()
            .ApplicationStopping.Register(LogManager.Shutdown);
    }
}
