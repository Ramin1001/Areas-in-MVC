using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using P208_ASP_Front.Models;

namespace P208_ASP_Front.Areas.Admin.Controllers
{
    [AuthorizeAdminFilter]
    public class SlidersController : Controller
    {
        private readonly AlstarEntities _db;

        public SlidersController()
        {
            _db = new AlstarEntities();
        }

        public ActionResult Index()
        {
            return View(_db.Sliders);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]    // Seyifede Slider tipinden gelenler olacaq Image-siz, Image ayrica gonderilrcek
        public ActionResult Create([Bind(Exclude = "Image")] Slider slider, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                if (Extensions.CheckImageType(Image) && Extensions.CheckImageSize(Image, 10))
                {
                    // verilen shekii metod vasitesi ile adini deyish ve bu unvanda saxla
                    slider.Image = Extensions.SaveImage(Server.MapPath("~/Public/img/intro"), Image);

                    _db.Sliders.Add(slider);
                    _db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Image", "Seklin tipi duzgun deyil ve ya olcusu 10mb-dan artiqdir.");
                }
            }

            return View();
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return HttpNotFound("ID is missing");

            Slider slider = _db.Sliders.Find(id);

            if (slider == null)
                return HttpNotFound("ID was not found");

            return View(slider);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return HttpNotFound("ID is missing");

            Slider slider = _db.Sliders.Find(id);

            if (slider == null)
                return HttpNotFound("ID was not found");

            return View(slider);
        }

        [HttpPost]
        public ActionResult Edit(Slider slider, HttpPostedFileBase NewImage)
        {
            if (ModelState.IsValid)
            {
                if(NewImage != null)
                {
                    Extensions.DeleteImage(Server.MapPath("~/Public/img/intro"), slider.Image);
                    slider.Image = Extensions.SaveImage(Server.MapPath("~/Public/img/intro"), NewImage);
                }

                _db.Entry(slider).State = EntityState.Modified;
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(slider);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return HttpNotFound("ID is missing");

            Slider slider = _db.Sliders.Find(id);

            if (slider == null)
                return HttpNotFound("ID was not found");

            return View(slider);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Slider slider = _db.Sliders.Find(id);

            if(!Extensions.DeleteImage(Server.MapPath("~/Public/img/intro"), slider.Image))
            {
                ViewBag.DeleteError = "File doesn't exist";
                return View();
            }

            _db.Sliders.Remove(slider);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}