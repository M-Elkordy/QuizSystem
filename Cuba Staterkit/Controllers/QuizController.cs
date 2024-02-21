using Cuba_Staterkit.Models;
using Cuba_Staterkit.RepoServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Net;

namespace Cuba_Staterkit.Controllers
{
    [Authorize]
    public class QuizController : Controller
    {
        private readonly IQuiz Quiz;
        private readonly IClassSession _session;
        private readonly IToastNotification toastNotification;


        public QuizController(IQuiz quiz, IClassSession session, IToastNotification _toastNotification)
        {
            Quiz = quiz;
            _session = session;
            toastNotification = _toastNotification;
        }

        [HttpGet]
        public IActionResult AllQuizes()
        {
            List<Quiz> Quizes = Quiz.GetAll();

            return View(Quizes);
        }

        [HttpPost]
        public IActionResult CreateQuiz(ClassSessionVm classSession)
        {
            bool sessionExists = _session.SessionExists(classSession.SessionName.ToLower());
            Session session;
            if(sessionExists) 
            {
                session = _session.GetSessionByName(classSession.SessionName);
            }  
            else
            {
                session = new Session() { ID = new Guid(), Name = classSession.SessionName.ToLower()};
                _session.InsertSession(session);
            }

                Quiz quiz = new Quiz() { Id = new Guid(), Name = classSession.QuizName, SessionID = session.ID };
                Quiz.InsertQuiz(quiz);

            // Create a new cookie
            Response.Cookies.Append("quizId", quiz.Id.ToString(), new CookieOptions
            {
                Expires = DateTime.Now.AddDays(1)
            });
            //return View(q);
            return RedirectToAction("CreateQuiz", "Assesment");
        }
    }
}
