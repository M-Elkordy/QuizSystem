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
            // Process the received data (questions) here
            // Example: Saving to database, performing some action, etc.
            // return Json(new { success = true, message = "Data received successfully." });

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

            return RedirectToAction("ActionName", "ControllerName");
        }


        //[HttpPost]
        //public IActionResult Create([FromBody] List<Question> questionsJson)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        // Process the received questions (e.g., save to the database)
        //        foreach (var q in questionsJson)
        //        {
        //            Question.InsertQuestion(q);
        //        }
        //    }

        //    return RedirectToAction("ActionName", "ControllerName");
        //}



        //[HttpPost]
        //public IActionResult Create([FromBody] List<Question> questionsJson)
        //{
        //    foreach (var question in questionsJson)
        //    {
        //        Console.WriteLine($"Question: Body={question.Body}, ImgUrl={question.ImgUrl}, CorrectAnswer={question.CorrectAnswer}, Answers={string.Join(",", question.Answers)}, QuizID={question.QuizID}, VersionID={question.VersionID}");
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        // Process the received questions (e.g., save to the database)
        //        foreach (var q in questionsJson)
        //        {
        //            Question.InsertQuestion(q);
        //        }
        //    }

        //    return RedirectToAction("Asses", "ControllerName");
        //}












        //public IActionResult Create(List<Question> questionsJson)
        //{
        //    //var questions = JsonConvert.DeserializeObject<Question[]>(questionsJson);
        //    if (ModelState.IsValid)
        //    {
        //        foreach (var q in questionsJson)
        //        {
        //            Question.InsertQuestion(q);
        //        }
        //    }

        //    //// Convert questionsJson to a string
        //    //string jsonString = JsonConvert.SerializeObject(questionsJson);
        //    //Console.WriteLine(jsonString);
        //    //// Deserialize the JSON string into an array of Question objects
        //    //var questions = JsonConvert.DeserializeObject<Question[]>(jsonString);

        //    //if (ModelState.IsValid)
        //    //{
        //    //    foreach (var q in questions)
        //    //    {
        //    //        Question.InsertQuestion(q);
        //    //    }
        //    //}

        //    return View();
        //}
    }
}
