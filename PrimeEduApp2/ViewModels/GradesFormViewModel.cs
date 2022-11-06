using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PrimeEduApp2.Models;

namespace PrimeEduApp2.ViewModels
{
    public class GradesFormViewModel
    {
        //initial viewmodel
        //public List<ExercisesDetails> ExercisesDetails { get; set; }
        //public Student Student { get; set; }

        //2nd thought
        //public List<ExercisesDetails> ExercisesDetails { get; set; }
        //public Student Student { get; set; }
        //public List<Exercise> Exercises { get; set; }

        //3rd
        public Student Student { get; set; }
        public ExercisesDetails ExercisesDetails { get; set; }
        public Exercise Exercise { get; set; }
        public List<ExercisesDetails> ExercisesDetailss { get; set; }
        public List<Student> Students { get; set; }
        public List<Exercise> Exercises { get; set; }


    }
}