using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cuba_Staterkit.Controllers
{
    [Authorize]
    public class PublishedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
