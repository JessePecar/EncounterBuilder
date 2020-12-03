using EncounterBuilder.Utilities;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;

namespace EncounterBuilder
{
    public class Program
    {
        private static bool _isService;
        public static void Main(string[] args)
        {
            _isService = !(Debugger.IsAttached || args.Contains("--console"));

            var builder = CreateWebHostBuilder(args);
            var host = builder.Build();

            if (_isService)
            {
                builder.UseSetting("https_port", "5001");
                //builder.UseSetting("http_port", "5000");
                builder.UseUrls("http://192.168.1.4:5000");

                // To run the app without the CustomWebHostService change the
                // next line to host.RunAsService();
                var webHostService = new RetailHostService(host);
                ServiceBase.Run(webHostService);
            }
            else
            {
                builder.UseUrls("https://localhost:5001");
                host.Run();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
                
    }
}
