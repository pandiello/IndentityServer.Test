namespace IdentityServer.Test
{
    using System;
    using System.IO;
    using Microsoft.AspNetCore.Hosting;


    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "Identity Server test!! :)";
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseUrls("http://localhost:5000")
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
