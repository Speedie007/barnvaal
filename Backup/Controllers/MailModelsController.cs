using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RiccoTest2.Models;

namespace RiccoTest2.Controllers
{
    public class MailModelsController : Controller
    {
        private RiccoTest2Context db = new RiccoTest2Context();

        // GET: MailModels
        public ActionResult Index()
        {
            return View(db.MailModels.ToList());
        }

        // GET: MailModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MailModel mailModel = db.MailModels.Find(id);
            if (mailModel == null)
            {
                return HttpNotFound();
            }
            return View(mailModel);
        }

        // GET: MailModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MailModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SMTP_HOST,SMTP_PORT,AccountName,AccountPassword,MessageBody,MessageSubject,FromAddress,ToAddress")] MailModel mailModel)
        {
            if (ModelState.IsValid)
            {
                db.MailModels.Add(mailModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mailModel);
        }

        // GET: MailModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MailModel mailModel = db.MailModels.Find(id);
            if (mailModel == null)
            {
                return HttpNotFound();
            }
            return View(mailModel);
        }

        // POST: MailModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SMTP_HOST,SMTP_PORT,AccountName,AccountPassword,MessageBody,MessageSubject,FromAddress,ToAddress")] MailModel mailModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mailModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mailModel);
        }

        // GET: MailModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MailModel mailModel = db.MailModels.Find(id);
            if (mailModel == null)
            {
                return HttpNotFound();
            }
            return View(mailModel);
        }

        // POST: MailModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MailModel mailModel = db.MailModels.Find(id);
            db.MailModels.Remove(mailModel);
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
