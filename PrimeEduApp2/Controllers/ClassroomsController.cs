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
        //private readonly ApplicationDbContext _context;
        private readonly ClassroomRepository _classroomRepository;


        public ClassroomsController()
        {
            //_context = new ApplicationDbContext();
            _classroomRepository = new ClassroomRepository();
        }
        // GET: Classroom
        public ActionResult Index()
        {
            var classrooms = _classroomRepository.GetAll();
            return View(classrooms.ToList());
        }

        public ActionResult StudentsPerClassroom(int? id)
        {
            var classroom = _classroomRepository.StudentsPerClassroom(id);
            return View(classroom);
        }

        public ActionResult ExercisesPerClassroom(int? id)
        {
            var classroomsEx = _classroomRepository.ExercisesPerClassroom(id);
            return View(classroomsEx);
        }


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
                //_context.Classrooms.Add(newClassroom);
                //_context.SaveChanges();
                _classroomRepository.Create(newClassroom);
                return RedirectToAction("Index");
            }
            return View(newClassroom);
        }

        public ActionResult Edit(int? id)
        {

            Classroom classroom = _classroomRepository.GetById(id);

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
                //_context.Entry(classroom).State = EntityState.Modified;
                //_context.SaveChanges();
                _classroomRepository.Update(classroom);
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
            Classroom classroom = _classroomRepository.GetById(id);

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
            //Classroom classroom = _context.Classrooms.Find(id);
            //_context.Classrooms.Remove(classroom);
            //_context.SaveChanges();
            _classroomRepository.Delete(id);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _classroomRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}