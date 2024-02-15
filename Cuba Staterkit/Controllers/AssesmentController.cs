using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace Cuba_Staterkit.Controllers
{
    [Authorize]
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
            // Read the value of the cookie
            string homeworkId = Request.Cookies["homeworkId"];

            ViewBag.HomeworkId = homeworkId;
            return View();
        }
    }
}
