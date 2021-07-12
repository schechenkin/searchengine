using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using SearchEngine.Core.Server.Indexes;

namespace SearchEngine.Controllers
{
    [Route("api/search")]
    [ApiController]
    [Produces("application/json")]
    public class SearchController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<SearchResponse>> Search([FromBody] SearchRequest request, [FromServices] RamSegment ramIndex)
        {
            var response = new SearchResponse
            {
                Data = new List<SearchResponse.Row>
                {
                    new SearchResponse.Row {  DocumentId = "1", Weight = 123 },
                    new SearchResponse.Row {  DocumentId = "2", Weight = 234 }
                }
            };

            return Ok(response);
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
            [JsonPropertyName("document_id")]
            public string DocumentId { get; set; }
            public double Weight { get; set; }
        }
    }
}
