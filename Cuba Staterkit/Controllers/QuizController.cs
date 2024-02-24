﻿using Cuba_Staterkit.Models;
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
        private readonly IQuiz _quiz;
        private readonly IClassSession _session;
        private readonly IToastNotification toastNotification;
        private readonly IQuestion _question;

        public QuizController(IQuiz quiz, IClassSession session, IToastNotification _toastNotification, IQuestion question)
        {
            _quiz = quiz;
            _session = session;
            toastNotification = _toastNotification;
            _question = question;
        }

        [HttpGet]
        public IActionResult AllQuizes()
        {
            List<Quiz> Quizes = _quiz.GetAll();

            return View(Quizes);
        }

        [HttpPost]
        public IActionResult CreateQuiz(ClassSessionVm classSession)
        {
            bool sessionExists = _session.SessionExists(classSession.SessionNumber);

            if (sessionExists)
            {
                // Session already exists, return JSON response
                return Json(new { sessionExists = true });
            }
            else
            {
                Session session = new Session() { ID = Guid.NewGuid(), Name = "Default", SessionNumber = classSession.SessionNumber };
                _session.InsertSession(session);

                Quiz quiz = new Quiz() { Id = Guid.NewGuid(), Name = classSession.QuizName, SessionID = session.ID };
                _quiz.InsertQuiz(quiz);

                //Response.Cookies.Append("quizId", quiz.Id.ToString(), new CookieOptions
                //{
                //    Expires = DateTime.Now.AddDays(1)
                //});
                toastNotification.AddSuccessToastMessage("Session / Quiz Added");

                // Session doesn't exist, return JSON response
                return Json(new { sessionExists = false });
            }
        }

        public IActionResult Edit(Guid id)
        {
            bool questionsExists = _quiz.QuizExist(id);
            if(questionsExists)
            {
                var quesions = _question.GetAllbyQuizId(id);
                var quiz = _quiz.GetQuizById(id);
                ViewBag.quiz = quiz;
                return View(quesions);
            }  
            else
            {
                return RedirectToAction("CreateQuiz", "Assesment", new {id = id});
            }
        }
        public void DeleteQuiz(Guid Id)
        {
            _session.DeleteSession(Id);
        }
    }
}