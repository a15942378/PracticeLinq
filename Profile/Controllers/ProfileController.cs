using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Profile.Models;

namespace Profile.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Home()
        {
            using (TESTEntities models = new TESTEntities()) 
            {
                var Data = from p in models.Data select p;
                return View(Data.ToList());
                //return View(models.Data.ToList());
            }   
        }
        public ActionResult Create()
        {
                return View();
        }
        [HttpPost]
        public ActionResult Create(Data data)
        {
            try 
            {
                using (TESTEntities models = new TESTEntities())
                {
                    models.Data.Add(data);
                    models.SaveChanges();
                }
                return RedirectToAction("Home");
            }
            catch 
            {
                return View();
            }
        }
        public ActionResult Update(int? id)
        {
            using (TESTEntities models = new TESTEntities())
            {
                if (id != null) {
                    var data = (from p in models.Data where p.No == id select p).FirstOrDefault();
                    //Data data = models.Data.Find(id);
                    return View(data);
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult Update(Data data)
        {
            try
            {
                using (TESTEntities models = new TESTEntities())
                {
                    //var NewData = models.Data.Single(q => q.No == data.No);
                    //NewData.Name = data.Name;
                    //NewData.Title = data.Title;
                    //NewData.Contents = data.Contents;
                    //models.SubmitChanges();
                    models.Entry(data).State = EntityState.Modified;
                    models.SaveChanges();
                }
                return RedirectToAction("Home");
            }
            catch
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
        }
        public ActionResult Delete(int? id)
        {
            using (TESTEntities models = new TESTEntities())
            {
                if (id != null)
                {
                    var data = (from p in models.Data where p.No == id select p).FirstOrDefault();
                    //Data data = models.Data.Find(id);
                    return View(data);
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (TESTEntities models = new TESTEntities())
            {
                var data = (from p in models.Data where p.No == id select p).FirstOrDefault();
                //Data data = models.Data.Find(id);
                models.Data.Remove(data);
                models.SaveChanges();
            }
            return RedirectToAction("Home");
        }
        public ActionResult CC()
        {
            return View();
        }
    }
}