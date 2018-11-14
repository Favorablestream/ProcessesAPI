using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Https;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace WebserviceTest
{
    public class Program
    {
        /// <summary>
        /// Path to HTTPS cert
        /// </summary>
        
        private const string CERT_PATH = "CERT_PATH";
        private const string CERT_PASSWORD = "CERT_PASSWORD";

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args).
            UseKestrel(options =>
            {
                options.Listen(IPAddress.Loopback, 5001, listenOptions =>
                {
                    var httpsOpts = new HttpsConnectionAdapterOptions();
                    httpsOpts.ServerCertificate = new X509Certificate2(CERT_PATH, CERT_PASSWORD);
                    listenOptions.UseHttps(httpsOpts);
                });
            })
            .UseStartup<Startup>();
    }
}
