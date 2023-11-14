using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lab7.Models;

namespace Lab7.Controllers
{
    public class TAAssignmentsController : Controller
    {
        private SRSDBEntities db = new SRSDBEntities();

        // GET: TAAssignments
        public ActionResult Index()
        {
            var tAAssignments1 = db.TAAssignments1.Include(t => t.Cours).Include(t => t.StudyTerm).Include(t => t.TAGrader);
            return View(tAAssignments1.ToList());
        }

        // GET: TAAssignments/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAAssignments tAAssignments = db.TAAssignments1.Find(id);
            if (tAAssignments == null)
            {
                return HttpNotFound();
            }
            return View(tAAssignments);
        }

        // GET: TAAssignments/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName");
            ViewBag.TermID = new SelectList(db.StudyTerms1, "TermID", "TermName");
            ViewBag.TAID = new SelectList(db.TAGraders1, "TAID", "TAFirstName");
            return View();
        }

        // POST: TAAssignments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TAAssignmentID,TAID,CourseID,TermID,AssignmentDate")] TAAssignments tAAssignments)
        {
            if (ModelState.IsValid)
            {
                db.TAAssignments1.Add(tAAssignments);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", tAAssignments.CourseID);
            ViewBag.TermID = new SelectList(db.StudyTerms1, "TermID", "TermName", tAAssignments.TermID);
            ViewBag.TAID = new SelectList(db.TAGraders1, "TAID", "TAFirstName", tAAssignments.TAID);
            return View(tAAssignments);
        }

        // GET: TAAssignments/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAAssignments tAAssignments = db.TAAssignments1.Find(id);
            if (tAAssignments == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", tAAssignments.CourseID);
            ViewBag.TermID = new SelectList(db.StudyTerms1, "TermID", "TermName", tAAssignments.TermID);
            ViewBag.TAID = new SelectList(db.TAGraders1, "TAID", "TAFirstName", tAAssignments.TAID);
            return View(tAAssignments);
        }

        // POST: TAAssignments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TAAssignmentID,TAID,CourseID,TermID,AssignmentDate")] TAAssignments tAAssignments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tAAssignments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", tAAssignments.CourseID);
            ViewBag.TermID = new SelectList(db.StudyTerms1, "TermID", "TermName", tAAssignments.TermID);
            ViewBag.TAID = new SelectList(db.TAGraders1, "TAID", "TAFirstName", tAAssignments.TAID);
            return View(tAAssignments);
        }

        // GET: TAAssignments/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAAssignments tAAssignments = db.TAAssignments1.Find(id);
            if (tAAssignments == null)
            {
                return HttpNotFound();
            }
            return View(tAAssignments);
        }

        // POST: TAAssignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TAAssignments tAAssignments = db.TAAssignments1.Find(id);
            db.TAAssignments1.Remove(tAAssignments);
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
