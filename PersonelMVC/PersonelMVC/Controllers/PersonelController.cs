using PersonelMVC.Models.EntityFramework;
using PersonelMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonelMVC.Controllers
{
    public class PersonelController : Controller
    {
        PersonelDbEntities db = new PersonelDbEntities();
        // GET: Personel
        public ActionResult Index()
        {
            var model = db.Personel.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult Kaydet()
        {
            var model = new PersonelFormViewModel() {Departmanlar = db.Departman.ToList() };
            return View("PersonelForm", model);
        }
        [HttpPost]
        public ActionResult Kaydet(Personel personel)
        {
            if (personel.Id == 0)//ekleme işlemi
            {
                db.Personel.Add(personel);
            }
            else//güncelleme işlemi
            {
                db.Entry(personel).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult update(int id)
        {
            var model = new PersonelFormViewModel() {
             Departmanlar = db.Departman.ToList(),
             Personel = db.Personel.Find(id)
            };
            return View("PersonelForm", model);
        }

        public ActionResult delete(int id)
        {
            var silinecekpersonel = db.Personel.Find(id);
            if (silinecekpersonel == null)
            {
                return HttpNotFound();
            }
            db.Personel.Remove(silinecekpersonel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}