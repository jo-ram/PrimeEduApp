using PrimeEduApp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeEduApp2.ViewModels
{
    public class ExerciseFormViewModel
    {
        public List<Classroom> Classrooms { get; set; }
        public Exercise Exercise { get; set; }
        //public List<Exercise> Exercises { get; set; }
    }
}