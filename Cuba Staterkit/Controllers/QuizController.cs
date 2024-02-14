using Cuba_Staterkit.Models;
using Cuba_Staterkit.RepoServices;
using Microsoft.AspNetCore.Mvc;

namespace Cuba_Staterkit.Controllers
{
    public class QuizController : Controller
    {
        private readonly IQuiz Quiz;
        private readonly IClassSession _session;

        public QuizController(IQuiz quiz, IClassSession session)
        {
            Quiz = quiz;
            _session = session;
        }

        [HttpPost]
        public IActionResult CreateQuiz(ClassSessionVm classSession)
        {
                Session session = new Session() { ID = new Guid(), Name = classSession.SessionName};
                _session.InsertSession(session);
                Quiz quiz = new Quiz() { Id = new Guid(), Name = classSession.QuizName, SessionID = session.ID};
                Quiz.InsertQuiz(quiz);

                // to pass data from controller to controller
                TempData["quizID"] = quiz.Id;
                TempData.Keep("quizID");
                return RedirectToAction("QuizForm", "Assesment");
            // return RedirectToAction("AssesmentForm", "Assesment");
        }
    }
}
