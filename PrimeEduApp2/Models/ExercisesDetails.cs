using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PrimeEduApp2.Models
{
    public class ExercisesDetails
    {
        public int ID { get; set; }
        public int ExerciseId {get;set;}
        public Exercise Exercise { get; set; }
        public Student Student { get; set; }
        public int StudentId { get; set; }
        public int Grade { get; set; }
    }
}