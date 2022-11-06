using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrimeEduApp2.Models
{
    public class Classroom
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Classroom name is required")]
        [StringLength(255, MinimumLength = 3)]
        public string ClassroomName { get; set; }

        public ICollection<Student> Students { get; set; }
        public ICollection<Exercise> Exercises { get; set; }
    }
}