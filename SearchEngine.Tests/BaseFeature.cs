using FluentAssertions;
using LightBDD.XUnit2;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SearchEngine.Tests
{
    public abstract class BaseFeature : FeatureFixture, IDisposable
    {
        protected HttpResponseMessage _response;

        protected HttpResponseMessage LastResponse => _response;

        public BaseFeature()
        {
        }


        protected void EnsureSuccessStatusCode()
        {
            _response.EnsureSuccessStatusCode();
        }

        protected async Task SendRequest(Func<Task<HttpResponseMessage>> action)
        {
            _response = await action();
        }

        public virtual void Dispose()
        {

        }

        protected async Task Then_server_returns_bad_request_response()
        {
            _response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        protected async Task Then_server_returns_OK_response()
        {
            _response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
