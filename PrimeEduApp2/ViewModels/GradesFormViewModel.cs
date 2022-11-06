using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PrimeEduApp2.Models;

namespace PrimeEduApp2.ViewModels
{
    public class GradesFormViewModel
    {
        public List<ExercisesDetails> ExercisesDetails { get; set; }
        //public List<Exercise> Exercises { get; set; }
        public Student Student { get; set; }
    }
}