using SearchEngine.Controllers;
using System.Net.Http;
using System.Threading.Tasks;

namespace SearchEngine.Tests.Extensions
{
    internal static class SearchApiExtensions
    {
        public static Task<HttpResponseMessage> Search(this HttpClient client, string index, string query)
        {
            return client.PostAsync($"api/search", new SearchRequest {  Index = index, Query = query }.ToJsonContent());
        }
    }
}
