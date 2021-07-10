using AspNetCore.Testing.Authentication.ClaimInjector;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;

namespace SearchEngine.Tests
{
    internal static class TestServer
    {
        public static SerarchEngineTestsWebApplicationFactory<Startup> ClientFactory { get; private set; }


        public static void Initialize()
        {
            ClientFactory = new SerarchEngineTestsWebApplicationFactory<Startup>();
            ClientFactory.CreateClient();
        }

        public static void Dispose() => ClientFactory.Dispose();
    }

    public class SerarchEngineTestsWebApplicationFactory<T> : ClaimInjectorWebApplicationFactory<T> where T : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            base.ConfigureWebHost(builder);

            builder.ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                config.AddJsonFile("appsettings.Tests.json", optional: true, reloadOnChange: true);

                config.AddEnvironmentVariables();
            });

            builder.ConfigureTestServices(services =>
            {
                
            });
        }
    }
}
