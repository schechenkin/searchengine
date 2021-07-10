using FluentAssertions;
using LightBDD.Framework;
using LightBDD.Framework.Scenarios;
using LightBDD.XUnit2;
using SearchEngine.Controllers;
using SearchEngine.Tests.Extensions;
using SearchEngine.Tests.Features.Fixtures;
using System.Threading.Tasks;
using Xunit;

namespace SearchEngine.Tests.Features.Search
{
    [FeatureDescription(@"")]
    [Trait("Search", "")]
    public class SearchFeature : BaseFeature, IClassFixture<TestUsersFixture>
    {
        public SearchFeature(TestUsersFixture users)
        {
            Users = users;
        }

        public TestUsersFixture Users { get; }

        [Scenario]
        public async Task RunSearch()
        {
            await Runner
                .AddAsyncStep("When user search", async _ =>
                {
                    _response = await Users.AnonimousClient.Search("index", "query");
                    EnsureSuccessStatusCode();
                })
                .AddAsyncStep("Then response contains valid response", async _ =>
                {
                    var result = await _response.BodyAs<SearchResponse>();
                    result.Error.Should().BeNullOrEmpty();
                    result.Data.Should().HaveCount(2);
                })
                .RunAsync();
        }
    }
}
