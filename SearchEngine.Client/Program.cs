using ConsoleTables;
using McMaster.Extensions.CommandLineUtils;
using Newtonsoft.Json;
using SearchEngine.Client.Extensions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json.Serialization;

namespace SearchEngine.Client
{
    public class Program
    {
        public static int Main(string[] args)
            => CommandLineApplication.Execute<Program>(args);

        [Option(Description = "Index name", ShortName = "i")]
        public string Index { get; }

        [Option(Description = "Query", ShortName = "q")]
        public string Query { get; }

        [Option(Description = "Route", ShortName = "r")]
        public string Route { get; } = "/api/search";

        [Option(ShortName = "p")]
        public int Port { get; } = 5000;

        private void OnExecute()
        {
            Console.WriteLine($"Execute request to port {Port} index {Index} query {Query}!");
            var client = new HttpClient();
            var response = client.PostAsync($"http://localhost:{Port}{Route}", new SearchRequest { Index = Index, Query = Query }.ToJsonContent()).Result;
            var searchResult = response.BodyAs<SearchResponse>().Result;

            if(string.IsNullOrEmpty(searchResult.Error))
            {
                ConsoleTable
                    .From<SearchResponse.Row>(searchResult.Data)
                    .Configure(o => o.NumberAlignment = Alignment.Right)
                    .Write(Format.Alternative);
            }
            else
            {
                Console.WriteLine($"Error {searchResult.Error}");
            }

        }
    }

    public class SearchRequest
    {
        public string Index { get; set; }
        public string Query { get; set; }
    }

    public class SearchResponse
    {
        public string Error { get; set; }
        public List<Row> Data { get; set; }

        public class Row
        {
            [JsonProperty("document_id")]
            public string DocumentId { get; set; }
            public double Weight { get; set; }
        }
    }
}
