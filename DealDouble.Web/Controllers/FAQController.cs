
using DealDouble.Entities;
using DealDouble.Services;
using DealDouble.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DealDouble.Web.Controllers
{
    public class FAQController : Controller
    {
        // GET: FAQ
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Help()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Feedback()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Feedback(FeedbackViewModel model)
        {
            FeedbackService feedbackService = new FeedbackService();
            Feedback feedback = new Feedback();
            



            feedback.Email = model.Email;
            feedback.Subject = model.Subject;
            feedback.Message = model.Message;
            feedbackService.SaveFeedback(feedback);
            return View(model);
        }

        public ActionResult Deatils()
        {
            FeedbackService feedbackService = new FeedbackService();
            FeedbackViewModel model = new FeedbackViewModel();
            model.feedback = feedbackService.GetAllFeedback();
            
            return View(model);
        }
    }
}