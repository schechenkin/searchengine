using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace SearchEngine.Controllers
{
    [Route("api/values")]
    [ApiController]
    [Produces("application/json")]
    public class ValuesController : ControllerBase
    {
        private readonly IOptions<SearchOptions> _settings;

        public ValuesController(IOptions<SearchOptions> settings)
        {
            _settings = settings;
        }
        
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("sum/{a}/{b}")]
        public async Task<ActionResult<int>> Sum(int a, int b)
        {
            return Ok(a + b);
        }
    }
}
