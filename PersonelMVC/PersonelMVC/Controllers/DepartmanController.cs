using PersonelMVC.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonelMVC.Controllers
{
    public class DepartmanController : Controller
    {
        PersonelDbEntities db = new PersonelDbEntities();
        // GET: Departman
        public ActionResult Index()
        {
            var model = db.Departman.ToList();
            return View(model);
        }


        [HttpGet]
        public ActionResult Kaydet()
        {
            return View("DepartmanForm");
        }
        [HttpPost]
        public ActionResult Kaydet(Departman departman)
        {
            if (departman.Id == 0) //ekleme işlemi
            {
                db.Departman.Add(departman);
            }
            else//güncelleme işlemi
            {
                var guncellenecekdepartman = db.Departman.Find(departman.Id);
                if (guncellenecekdepartman == null)
                    return HttpNotFound();
                guncellenecekdepartman.Ad = departman.Ad;

            }
            db.SaveChanges();
            return RedirectToAction("Index","Departman");
        }

        public ActionResult Guncelle(int id)
        {
            var model = db.Departman.Find(id);
            if (model == null)
                return HttpNotFound();
            return View("DepartmanForm", model);
        }

        public ActionResult Sil (int id)
        {
            var silinecekdepartman = db.Departman.Find(id);
            if (silinecekdepartman == null)
                return HttpNotFound();
            db.Departman.Remove(silinecekdepartman);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}