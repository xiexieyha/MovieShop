using Movieshop.API;

CreateHostBuilder().Build().Run();

 static IHostBuilder CreateHostBuilder()
{
    return Host.CreateDefaultBuilder().ConfigureWebHostDefaults(webhost => {

        webhost.UseStartup<Startup>();

    });
}
