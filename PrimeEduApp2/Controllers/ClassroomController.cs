using PrimeEduApp2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrimeEduApp2.Controllers
{
    public class ClassroomController : Controller
    {
        private readonly ApplicationDbContext _context;


        public ClassroomController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Classroom
        public ActionResult Index()
        {
            var classrooms = _context.Classrooms.ToList();
            return View(classrooms);
        }

        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
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

    }
}