using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using P208_ASP_Front.Models;
using P208_ASP_Front.ViewModels;

namespace P208_ASP_Front.Controllers
{
    public class HomeController : Controller
    {
        private readonly AlstarEntities _db;

        public HomeController()
        {
            _db = new AlstarEntities();
        }

        public ActionResult Index()
        {
            HomeIndexVM vm = new HomeIndexVM
            {
                Sliders = _db.Sliders.ToList(),
                About = _db.Abouts.First(),
                Parallax =_db.Parallaxes.First()
            };

            return View(vm);
        }

        public ActionResult Services()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}