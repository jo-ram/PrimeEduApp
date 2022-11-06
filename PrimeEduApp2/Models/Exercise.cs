using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrimeEduApp2.Models
{
    public class Exercise
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Exercise name is required")]
        [StringLength(255, MinimumLength = 3)]
        public string ExerciseName { get; set; }
        public int ClassroomID { get; set; }
        public Classroom Classroom { get; set; }
        public List<ExercisesDetails> ExercisesDetails { get; set; }
    }
}