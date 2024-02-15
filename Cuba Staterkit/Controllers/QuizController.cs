using Cuba_Staterkit.Models;
using Cuba_Staterkit.RepoServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Cuba_Staterkit.Controllers
{
    [Authorize]
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
            // dealing with session in creation of quiz
            bool sessionExists = _session.SessionExists(classSession.SessionName.ToLower());
            Session session;
            if(sessionExists) 
            {
                session = _session.GetSessionByName(classSession.SessionName);
            }  
            else
            {
                session = new Session() { ID = new Guid(), Name = classSession.SessionName.ToLower() };
                _session.InsertSession(session);
            }

            Quiz quiz = new Quiz() { Id = new Guid(), Name = classSession.QuizName, SessionID = session.ID};
            Quiz.InsertQuiz(quiz);

            // Create a new cookie
            Response.Cookies.Append("quizId", quiz.Id.ToString(), new CookieOptions
            {
                Expires = DateTime.Now.AddDays(1)
            });

            return RedirectToAction("QuizForm", "Assesment");
        }
    }
}
