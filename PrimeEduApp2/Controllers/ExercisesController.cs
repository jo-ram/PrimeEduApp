using PrimeEduApp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PrimeEduApp2.ViewModels;
using System.Net;

namespace PrimeEduApp2.Controllers
{
    public class ExercisesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ExercisesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Exercises
        public ActionResult Index()
        {
            var exercises = _context.Exercises.Include(c => c.Classroom);
            return View(exercises.ToList());
        }

        public ActionResult Create()
        {
            var classrooms = _context.Classrooms.ToList();
            var viewmodel = new ExerciseFormViewModel()
            {
                Exercise = new Exercise(),
                Classrooms = classrooms
            };

            return View("Create", viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Exercise exercise)
        {
            _context.Exercises.Add(exercise);
            if (!ModelState.IsValid)
            {
                var viewModel = new ExerciseFormViewModel()
                {
                    Exercise = exercise,
                    Classrooms = _context.Classrooms.ToList()
                };
                return View("Create", viewModel);
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            var exercise = _context.Exercises.Include(c => c.Classroom).SingleOrDefault(e => e.ID == id);
            var viewmodel = new ExerciseFormViewModel()
            {
                Exercise = exercise,
                Classrooms = _context.Classrooms.ToList()
            };

            if(exercise == null)
            {
                return HttpNotFound();
            }

            return View("Edit", viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ExerciseFormViewModel exform)
        {
            if (!ModelState.IsValid)
            {
                exform.Classrooms = _context.Classrooms.ToList();
                return View("Edit", exform);
            }

            var exFromDb = _context.Exercises.Find(exform.Exercise.ID);
            exFromDb.ExerciseName = exform.Exercise.ExerciseName;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exercise exercise = _context.Exercises
                .Include(c => c.Classroom)
                .SingleOrDefault(s => s.ID == id);

            if (exercise == null)
            {
                return HttpNotFound();
            }
            return View(exercise);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Exercise exercise = _context.Exercises.Find(id);
            _context.Exercises.Remove(exercise);
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