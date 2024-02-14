using Cuba_Staterkit.Models;
using Cuba_Staterkit.RepoServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Nodes;

namespace Cuba_Staterkit.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestion Question;
        public QuestionController(IQuestion question)
        {
            Question = question;
        }

        [HttpPost]
        public ActionResult Create([FromBody] List<QuestionViewModel> questions)
        {
            if (ModelState.IsValid)
            {
                // Process the received questions (e.g., save to the database)
                foreach (var q in questions)
                {
                    Question question = new Question()
                    {
                        ID = new Guid(), 
                        Body = q.Body,
                        ImgUrl = q.ImgUrl,
                        Answers  = string.Join(",", q.Answers),
                        CorrectAnswer = q.CorrectAnswer,
                        VersionID = q.VersionID,
                        QuestionType = Questiontype.String,
                        AnswerType = Questiontype.String,
                        QuizID = new Guid(q.QuizID),
                    };
                    Question.InsertQuestion(question);
                }
            }
            return RedirectToAction("QuizForm", "Assesment");
        }
    }
}
