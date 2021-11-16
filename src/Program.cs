using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ContosoCrafts.WebSite
{
    public class Program
    {
        //Main method that builds host with arguments and runs
        public static void Main(string[] args)
        {

            //runs code on a builder object
            CreateHostBuilder(args).Build().Run();
        
        }

        //CreateHostBuilder method to configure the host without running the app
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {

                    webBuilder.UseStartup<Startup>();
                
                });
    }
}