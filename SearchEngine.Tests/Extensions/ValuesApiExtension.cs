using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine.Tests.Extensions
{
    internal static class ValuesApiExtensions
    {
        public static Task<HttpResponseMessage> GetSum(this HttpClient client, int a, int b)
        {
            return client.GetAsync($"api/values/sum/{a}/{b}");
        }
    }
}
