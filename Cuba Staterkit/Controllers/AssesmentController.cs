using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


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
            // Read the value of the cookie
            string quizId = Request.Cookies["quizId"];

            ViewBag.QuizId = quizId;
            return View();
        }

        public IActionResult HomeworkForm()
        {
            return View();
        }
    }
}
