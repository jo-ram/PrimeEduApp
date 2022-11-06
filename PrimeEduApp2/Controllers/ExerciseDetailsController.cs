using PrimeEduApp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace PrimeEduApp2.Controllers
{
    public class ExerciseDetailsController : Controller
    {
        // GET: ExerciseDetails
        private readonly ApplicationDbContext _context;
        public ExerciseDetailsController()
        {
            _context = new ApplicationDbContext();
        }
        //GET: Exercises
        //public ActionResult Index()
        //{
        //    var grades = _context.Students.Include(e => e.ExercisesDetails.Select(ex => ex.Grade));
        //    return View(grades);
        //}

    }
}