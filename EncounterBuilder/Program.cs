using ElectronNET.API;
using EncounterBuilder.Utilities;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.ServiceProcess;

namespace EncounterBuilder
{
    public class Program
    {
        private static bool _isService;
        public static void Main(string[] args)
        {
            _isService = !(Debugger.IsAttached || args.Contains("--console"));
            var builder = CreateHostBuilder(args);
            var host = builder.Build();

            if (_isService)
            {

                //builder.UseUrls("http://192.168.1.4:5000");

                // To run the app without the CustomWebHostService change the
                // next line to host.RunAsService();
                host.Run();
            }
            else
            {
                host.Run();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(ConfigureConfiguration)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
                
                webBuilder.ConfigureKestrel(options =>
                {
                    options.Limits.MinRequestBodyDataRate =
                        new MinDataRate(bytesPerSecond: 100,
                            gracePeriod: TimeSpan.FromSeconds(10));
                    options.Limits.MinResponseDataRate =
                        new MinDataRate(bytesPerSecond: 100,
                            gracePeriod: TimeSpan.FromSeconds(10));
                    options.Listen(IPAddress.Loopback, 5000);
                    options.Limits.KeepAliveTimeout = TimeSpan.FromHours(5);
                });
            });


        private static void ConfigureConfiguration(IConfigurationBuilder config)
        {
            config.SetBasePath(@"C:\APPLICATIONS\Configuration");
            config.AddJsonFile("Global.json", false, true);
        }
    }
}
