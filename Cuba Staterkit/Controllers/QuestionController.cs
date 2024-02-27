using Cuba_Staterkit.Models;
using Cuba_Staterkit.RepoServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NToastNotify;
using System.Text.Json.Nodes;
using static System.Collections.Specialized.BitVector32;

namespace Cuba_Staterkit.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestion Question;
        private readonly IToastNotification toastNotification;
        public QuestionController(IQuestion question, IToastNotification _toastNotification)
        {
            Question = question;
            toastNotification = _toastNotification;
        }

      

            [HttpPost]
        public ActionResult Create([FromBody] List<QuestionViewModel> questions)
        {
            if (ModelState.IsValid)
            {
                // Generate a GUID for the first question
                Guid firstQuestionId = Guid.NewGuid();

                // Process the received questions (e.g., save to the database)
                for (int i = 0; i < questions.Count; i++)
                {
                    Question question = new Question()
                    {
                        ID = (i==0) ? firstQuestionId : Guid.NewGuid(), // Generate a new GUID for each question
                        Body = questions[i].Body,
                        ImgUrl = questions[i].ImgUrl,
                        Answers = string.Join(",", questions[i].Answers),
                        CorrectAnswer = questions[i].CorrectAnswer,
                        QuestionType = Questiontype.String,
                        AnswerType = Questiontype.String,
                        QuizID = new Guid(questions[i].QuizID),
                        VersionID = firstQuestionId.ToString(), // Set VersionID to the ID of the first question for all questions
                    };

                    Question.InsertQuestion(question);
                }

            }
            toastNotification.AddSuccessToastMessage("Questions Added Successfully");
            return RedirectToAction("CreateQuiz", "Assesment");
        }

        [HttpPost]
        public ActionResult CreateHomework([FromBody] List<QuestionHomeworkViewModel> questions)
        {
            if (ModelState.IsValid)
            {
                // Generate a GUID for the first question
                Guid firstQuestionId = Guid.NewGuid();

                // Process the received questions (e.g., save to the database)
                for (int i = 0; i < questions.Count; i++)
                {
                    Question question = new Question()
                    {
                        ID = (i == 0) ? firstQuestionId : Guid.NewGuid(), // Generate a new GUID for each question
                        Body = questions[i].Body,
                        ImgUrl = questions[i].ImgUrl,
                        Answers = string.Join(",", questions[i].Answers),
                        CorrectAnswer = questions[i].CorrectAnswer,
                        QuestionType = Questiontype.String,
                        AnswerType = Questiontype.String,
                        HomeWorkID = new Guid(questions[i].HomeworkId),
                        VersionID = firstQuestionId.ToString(), // Set VersionID to the ID of the first question for all questions
                    };

                    Question.InsertQuestion(question);
                }
            }
            return RedirectToAction("CreateHomework", "Assesment");
        }


        public ActionResult EditQuestions(string id)
        {

            var questions = Question.GetQuestionById(id).ToList();
            return View(questions);
        }




    }
}
