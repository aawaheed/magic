/*
 * Copyright (c) Thomas Hansen, 2021 - 2023 thomas@ainiro.io.
 */

using System;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using magic.data.common.helpers;

namespace magic.backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (PosixSignalRegistration.Create(PosixSignal.SIGTERM, context => {
                if (!ShutdownLock.StartShutdown())
                {
                    Console.WriteLine("Waiting for application to clean up");
                    context.Cancel = true;
                }
                else
                {
                    Console.WriteLine("Shutting down application immediately");
                }
            }))
            {
                Host.CreateDefaultBuilder(args)
                    .ConfigureWebHostDefaults(webBuilder =>
                    {
                        webBuilder
                            .ConfigureAppConfiguration((ctx, config) =>
                            {
                                config.AddJsonFile("files/config/appsettings.json", optional: false, reloadOnChange: true);
                            })
                            .ConfigureKestrel(options =>
                            {
                                options.Limits.KeepAliveTimeout = TimeSpan.FromSeconds(180);
                                options.Limits.RequestHeadersTimeout = TimeSpan.FromSeconds(180);
                                options.Limits.MaxRequestBodySize = 262144000; // 250MB
                            })
                            .UseStartup<Startup>();
                    })
                    .Build()
                    .Run();
            }
        }
    }
}
