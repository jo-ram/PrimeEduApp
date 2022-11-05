using PrimeEduApp2.Models;
using PrimeEduApp2.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PrimeEduApp2.Controllers
{
    public class ClassroomsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ClassroomRepository _classroomRepository;


        public ClassroomsController()
        {
            _context = new ApplicationDbContext();
            _classroomRepository = new ClassroomRepository();
        }
        // GET: Classroom
        public ActionResult Index()
        {
            var classrooms = _context.Classrooms.ToList();
            return View(classrooms);
        }

        public ActionResult StudentsPerClassroom(int? id)
        {
            var classroom = _context.Classrooms.Include(s => s.Students).SingleOrDefault(c => c.ID == id);
            return View(classroom);
        }

        //public ActionResult StudentsPerClassroom2(int? id)
        //{
        //    var classrooms = _context.Classrooms.Include(s=>s.Students).Where(s=> s.ID ==id).ToList();
        //    return View(classrooms);
        //}



        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Classroom newClassroom) 
        {
            if (ModelState.IsValid)
            {
                _context.Classrooms.Add(newClassroom);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newClassroom);
        }

        public ActionResult Edit(int? id)
        {

            Classroom classroom = _context.Classrooms.Find(id);

            if (classroom == null)
            {
                return HttpNotFound();
            }
            return View(classroom);
        }

        [HttpPost]
        public ActionResult Edit(Classroom classroom)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(classroom).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classroom);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classroom classroom = _context.Classrooms
                .SingleOrDefault(s => s.ID == id);

            if (classroom == null)
            {
                return HttpNotFound();
            }
            return View(classroom);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Classroom classroom = _context.Classrooms.Find(id);
            _context.Classrooms.Remove(classroom);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}