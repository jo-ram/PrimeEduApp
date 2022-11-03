using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeEduApp2.Models
{
    public class Classroom
    {
        public int ID { get; set; }
        public string ClassroomName { get; set; }

        public ICollection<Student> Students { get; set; }
        public ICollection<Exercise> Exercises { get; set; }
    }
}