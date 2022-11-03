﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeEduApp2.Models
{
    public class Teacher
    {
        public int ID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
         
        public int ClassroomID { get; set; }
        public Classroom Classroom { get; set; }
    }
}