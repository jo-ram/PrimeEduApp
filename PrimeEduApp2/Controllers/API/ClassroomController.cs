using PrimeEduApp2.Models;
using PrimeEduApp2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PrimeEduApp2.Controllers.API
{
    public class ClassroomController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public ClassroomRepository Classrooms = new ClassroomRepository();

        public ClassroomController()
        {
            _context = new ApplicationDbContext();

        }


        [HttpDelete]
        public IHttpActionResult Delete(int? id)
        {
            var classroom = Classrooms.GetById(id);

            if (classroom == null)
                return NotFound();

            _context.Classrooms.Remove(classroom);
            _context.SaveChanges();

            return Ok();
        }
    }
}
