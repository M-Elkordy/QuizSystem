using Microsoft.AspNetCore.Mvc;

namespace Cuba_Staterkit.Controllers
{
    public class AssesmentController : Controller
    {
        public IActionResult AssesmentForm()
        {
            return View();
        }
        //public IActionResult QuizForm()
        //{
        //    Guid quizId = Guid.Empty;
        //    quizId = (Guid)TempData["quizID"];
        //    ViewBag.QuizId = quizId;
        //    return View();
        //}

        public IActionResult QuizForm()
        {
            //Guid quizId = Guid.Empty;
            //quizId = (Guid)TempData["quizID"];
            string id = "709afaa4-4d35-459d-e608-08dc2b50845e";
            var quizId = new Guid(id);
            ViewBag.QuizId = quizId;
            return View();
        }

        public IActionResult HomeworkForm()
        {
            return View();
        }
    }
}
