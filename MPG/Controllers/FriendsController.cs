using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MPG.Models;



namespace MPG.Controllers
{
    public class FriendsController : Controller
    {
        private MPGEntities db = new MPGEntities();

        // GET: Friends
        public ActionResult Index(string searchString)
        {
            //string searchString = id;
            var friends = from f in db.Friends
                          select f;

            if (!String.IsNullOrEmpty(searchString))
            {
                friends = friends.Where(s => s.FirstName.Contains(searchString) || s.LastName.Contains(searchString) || s.CarModel.Contains(searchString));

            }
            //else if (!String.IsNullOrEmpty(searchString))
            //{
            //    friends = friends.Where(s => s.LastName.Contains(searchString));
            //}
            //else if (!String.IsNullOrEmpty(searchString))
            //{
            //    friends = friends.Where(s => s.CarModel.Contains(searchString));
            //}
            //else if (!String.IsNullOrEmpty(searchString))
            //{
            //    friends = friends.Where(s => Convert.ToString(s.FillUpDate).Contains(searchString));
            //}
            //return View(db.Friends.ToList()
            //        .OrderBy(x => x.FillUpDate)
            //        .ThenBy(x => x.LastName)
            //        .ThenBy(x => x.CarModel));
            return View(friends);
        }


        // GET: Friends/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Friend friend = db.Friends.Find(id);
            if (friend == null)
            {
                return HttpNotFound();
            }
            return View(friend);
        }

        // GET: Friends/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Friends/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,CarModel,MilesDriven,GallonsFilled,FillUpDate")] Friend friend)
        {
            if (ModelState.IsValid)
            {
                db.Friends.Add(friend);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(friend);
        }

        // GET: Friends/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Friend friend = db.Friends.Find(id);
            if (friend == null)
            {
                return HttpNotFound();
            }
            return View(friend);
        }

        // POST: Friends/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,CarModel,MilesDriven,GallonsFilled,FillUpDate")] Friend friend)
        {
            if (ModelState.IsValid)
            {
                db.Entry(friend).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(friend);
        }

        // GET: Friends/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Friend friend = db.Friends.Find(id);
            if (friend == null)
            {
                return HttpNotFound();
            }
            return View(friend);
        }

        // POST: Friends/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Friend friend = db.Friends.Find(id);
            db.Friends.Remove(friend);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        
    }
}
