using LightBDD.Core.Configuration;
using LightBDD.XUnit2;
using SearchEngine.Tests;
using System;
using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]
[assembly: ConfiguredLightBddScope]

namespace SearchEngine.Tests
{
    internal class ConfiguredLightBddScopeAttribute : LightBddScopeAttribute
    {
        protected override void OnSetUp()
        {
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Tests");

            TestServer.Initialize();
        }

        protected override void OnTearDown()
        {
            TestServer.Dispose();
        }

        protected override void OnConfigure(LightBddConfiguration configuration)
        {
            base.OnConfigure(configuration);

            configuration.ExecutionExtensionsConfiguration();

        }
    }
}
