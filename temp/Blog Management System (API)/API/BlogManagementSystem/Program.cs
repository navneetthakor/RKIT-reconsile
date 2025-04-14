CreateHostBuilder(args).Build().Run();

// Create Builder.
static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            // Configer Startup file
            webBuilder.UseStartup<Startup>();

        });
