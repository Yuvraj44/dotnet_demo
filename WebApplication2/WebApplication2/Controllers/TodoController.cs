using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [ApiController]
    public class TodoController : Controller
    {
        [HttpGet(Name = "home")]
        public IActionResult Index()
        {
            return Content("Hello");
        }
    }
}
