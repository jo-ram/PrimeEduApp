using PrimeEduApp2.Models;
using PrimeEduApp2.Repositories;
using PrimeEduApp2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;

namespace PrimeEduApp2.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly StudentRepository _studentRepository;
        private readonly ClassroomRepository _classroomRepository;
        public StudentsController()
        {
            _context = new ApplicationDbContext();
            _studentRepository = new StudentRepository();
            _classroomRepository = new ClassroomRepository();
        }

        // GET: Students
        public ActionResult Index()
        {
            var students = _context.Students.Include(c => c.Classroom);
            return View(students.ToList());
        }

        public ActionResult Grades(int? id)
        {
            var grades = _context.ExercisesDetails.Include(e => e.Exercise).Where(ex => ex.StudentId == id).ToList();
            var student = _context.Students.SingleOrDefault(s => s.ID == id);

            var viewmodel = new GradesFormViewModel() 
            {
                ExercisesDetails = grades,
                Student = student
            };

            return View(viewmodel);
        }

        //public ActionResult StudentsPerClass(int? id)
        //{
        //    Student student = _context.Students.Include(c => c.Classrooms).SingleOrDefault(a => a.ClassroomID == id);

        //    if (student == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View();
        //}

        public ActionResult Create()
        {
            var classrooms = _context.Classrooms.ToList();
            var viewmodel = new StudentFormViewModel()
            {
               Student = new Student(),
                Classrooms = classrooms
            };
           
            return View("Create", viewmodel);   
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            _context.Students.Add(student);
            if (!ModelState.IsValid)
            {
                var viewModel = new StudentFormViewModel()
                {
                    Student = student,
                    Classrooms = _context.Classrooms.ToList()
                };
                return View("Create", viewModel);
            }
           
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {

            var student = _context.Students
                .Include(c=>c.Classroom)
                .SingleOrDefault(s => s.ID == id);

            var viewmodel = new StudentFormViewModel()
            {
                Student = student,
                Classrooms = _context.Classrooms.ToList()
            };

            if (student == null)
            {
                return HttpNotFound();
            }
            return View("Edit", viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(StudentFormViewModel stform)
        {

            if (!ModelState.IsValid)
            {
                stform.Classrooms = _context.Classrooms.ToList();
                return View("Edit", stform);
            };

            var studentformdb = _context.Students.Find(stform.Student.ID);
            studentformdb.FirstName = stform.Student.FirstName;
            studentformdb.LastName = stform.Student.LastName;
            studentformdb.ClassroomID = stform.Student.ClassroomID;

            _context.SaveChanges();
            return RedirectToAction("Index");

        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = _context.Students
                .Include(c => c.Classroom)
                .SingleOrDefault(s => s.ID == id);

            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Student student = _context.Students.Find(id);
            _context.Students.Remove(student);
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