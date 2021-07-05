using System.Collections.Generic;
using System.Threading.Tasks;
using CustomSearchEngine.Models;
using CustomSearchEngine.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CustomSearchEngine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchEngineController : ControllerBase
    {
        // GET localhost/api/SearchEngine/google?keywords=e-settlements&matchUrl=www.sympli.com.au
        [HttpGet("{searchEngine}")]
        public async Task<ActionResult<SearchResponse>> FetchRankingPositionBySearchEngine(
            string searchEngine,
            [FromServices] Dictionary<string, IEngine> searchEngines,
            [FromQuery] SearchRequest searchRequest)
        {
            if (!searchEngines.ContainsKey(searchEngine))
            {
                ModelState.AddModelError("SearchEngine", $"Search engine: {searchEngine} is not supported");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await searchEngines[searchEngine].GetRankingPosition(searchRequest.Keywords, searchRequest.MatchUrl);
            return new SearchResponse(result);
        }
    }
}
