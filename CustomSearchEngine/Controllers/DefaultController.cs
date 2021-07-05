using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace CustomSearchEngine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
