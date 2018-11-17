using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace gorpsgen
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseKestrel(options =>
                {
                    var configuration = (IConfiguration)options.ApplicationServices.GetService(typeof(IConfiguration));
                    var httpsPort = configuration.GetValue("ASPNETCORE_HTTPS_PORT", 5001); // takes from environment
                    var certPassword = configuration.GetValue<string>("CertPassword"); // takes from environment
                    var certPath = configuration.GetValue<string>("CertPath"); //takes from environment

                    Console.WriteLine($"{nameof(httpsPort)}: {httpsPort}");
                    Console.WriteLine($"{nameof(certPassword)}: {certPassword}");
                    Console.WriteLine($"{nameof(certPath)}: {certPath}");

                    //IPAddress.Loopback doesn't work in Docker
                    options.Listen(IPAddress.Any, httpsPort, listenOptions =>
                    {
                        //var certificate = new X509Certificate2(certPath, certPassword);
                        //var httpsConnectionAdapterOptions = new HttpsConnectionAdapterOptions()
                        //{
                        //    ClientCertificateMode = ClientCertificateMode.NoCertificate,
                        //    SslProtocols = System.Security.Authentication.SslProtocols.Tls,
                        //    ServerCertificate = certificate
                        //};
                        //listenOptions.UseHttps(httpsConnectionAdapterOptions);
                        listenOptions.UseHttps(certPath, certPassword);
                    });
                });
    }
}
