using SurveyTask.Models;
using SurveyTask.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SurveyTask.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            IQueryable<Surveycount> data = from customer in db.Customers
                                                             group customer by customer.Age into surveyGroup
                                                             select new Surveycount()
                                                             {
                                                                 Age = surveyGroup.Key,
                                                                 CustomerCount = surveyGroup.Count()
                                                             };
            return View(data.ToList());
        }
      

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}