using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Https;
using Microsoft.Extensions.Hosting;

namespace Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                        .ConfigureKestrel(options =>
                        {
                            options.Listen(IPAddress.Any, 50051, listenOptions => listenOptions.UseHttps("D:/Projects/grpctests/Development/Certificates/grpctests.pfx", "welkom01"));
                            options.ConfigureHttpsDefaults(opt => opt.ClientCertificateMode = ClientCertificateMode.RequireCertificate);
                        });
                });
    }
}
