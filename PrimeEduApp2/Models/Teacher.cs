using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrimeEduApp2.Models
{
    public class Teacher
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Firstname is required")]
        [StringLength(255, MinimumLength = 3)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Lastname is required")]
        [StringLength(255, MinimumLength = 3)]
        public string LastName { get; set; }
         
        public int ClassroomID { get; set; }
        public Classroom Classroom { get; set; }
    }
}