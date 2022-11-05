using PrimeEduApp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeEduApp2.ViewModels
{
    public class StudentFormViewModel
    {
        public List<Classroom> Classrooms { get; set; }
        public Student Student { get; set; }
        //public List<Student> Students { get; set; }
    }
}