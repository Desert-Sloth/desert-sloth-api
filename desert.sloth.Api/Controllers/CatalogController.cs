using Microsoft.AspNetCore.Mvc;
//using desert.sloth.Domain.Catalog;

namespace desert.sloth.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetItems(){
            return Ok("Hello World!");
        }
    }
}