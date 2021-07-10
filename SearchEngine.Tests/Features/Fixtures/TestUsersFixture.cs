using AspNetCore.Testing.Authentication.ClaimInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace SearchEngine.Tests.Features.Fixtures
{
    public class TestUsersFixture : BaseFixture, IDisposable
    {
        public HttpClient AnonimousClient, BobClient;
        private ClaimInjectorWebApplicationFactory<Startup> _factory;

        public TestUsersFixture()
        {
            _factory = TestServer.ClientFactory;

            this._factory.RoleConfig.Reset();

            AnonimousClient = BuildAnonimousClient();
            BobClient = BuildClient("bob");
        }

        public void Dispose()
        {

        }

        protected HttpClient BuildClient(string account)
        {
            this._factory.RoleConfig.Reset();
            this._factory.RoleConfig.Name = account;

            return this._factory.CreateDefaultClient(new HttpLoggingHandler(new HttpClientHandler()));
        }

        protected HttpClient BuildAnonimousClient()
        {
            this._factory.RoleConfig.Reset();
            this._factory.RoleConfig.AnonymousRequest = true;

            return this._factory.CreateDefaultClient(new HttpLoggingHandler(new HttpClientHandler()));
        }
    }
}
