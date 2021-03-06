﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuizDataLibrary;

namespace QuizTaker.Controllers
{
    [Authorize]
    public class QuestionController : Controller
    {
        private readonly IQuestion _questionRepo;
        private readonly ILogger<QuestionController> _logger;

        public QuestionController(IQuestion questionRepo, ILogger<QuestionController> logger)
        {
            _questionRepo = questionRepo;
            _logger = logger;
        }

        // GET: Question
        public ActionResult Index()
        {
            var question = _questionRepo.ListAllQuestions();
            return View(_questionRepo.ListAllQuestions());
        }

        // GET: Question/Details/5
        public ActionResult Details(int id)
        {
            return View(_questionRepo.GetById(id));
        }

        // GET: Question/Create
        public ActionResult Create()
        {
            Question newQuestion = new Question();

            return View(newQuestion);
        }

        // POST: Question/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Question newQuestion, IFormCollection collection)
        {
            try
            {

                if (ModelState.IsValid)
                {
                   _questionRepo.AddQuestion(newQuestion);
                }
                
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to create a question: {ex}");
                return View(newQuestion);
            }
        }

        // GET: Question/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_questionRepo.GetById(id));
        }

        // POST: Question/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Question editQuestion, IFormCollection collection)
        {
            try
            {
                _questionRepo.EditQuestion(editQuestion);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to edit a question: {ex}");
                return View(editQuestion);
            }
        }

        // GET: Question/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_questionRepo.GetById(id));
        }

        // POST: Question/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Question deleteQuestion, IFormCollection collection)
        {
            try
            {
                _questionRepo.DeleteQuestion(id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to delete a question: {ex}");
                return View();
            }
        }
    }
}