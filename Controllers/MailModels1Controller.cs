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
    public class MailModels1Controller : Controller
    {
        private RiccoTest2Context db = new RiccoTest2Context();

        // GET: MailModels1
        public ActionResult Index()
        {
            return View(db.MailModels.ToList());
        }

        // GET: MailModels1/Details/5
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

        // GET: MailModels1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MailModels1/Create
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

        // GET: MailModels1/Edit/5
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

        // POST: MailModels1/Edit/5
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

        // GET: MailModels1/Delete/5
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

        // POST: MailModels1/Delete/5
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
