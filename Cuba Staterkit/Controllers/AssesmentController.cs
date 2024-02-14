using Microsoft.AspNetCore.Mvc;

namespace Cuba_Staterkit.Controllers
{
    public class AssesmentController : Controller
    {
        public IActionResult AssesmentForm()
        {
            return View();
        }
        public IActionResult QuizForm()
        {
            return View();
        }

        public IActionResult HomeworkForm()
        {
            return View();
        }
    }
}
