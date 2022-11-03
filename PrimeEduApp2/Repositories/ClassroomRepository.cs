using PrimeEduApp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeEduApp2.Repositories
{
    public class ClassroomRepository : IDisposable
    {
        private readonly ApplicationDbContext _context;
        public ClassroomRepository()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Classroom> GetAll()
        {
            return _context.Classrooms;
        }
        public Classroom GetById(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return _context.Classrooms
                .SingleOrDefault(a => a.ID == id);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}