using PrimeEduApp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeEduApp2.Repositories
{
    public class StudentRepository : IDisposable
    {
        private readonly ApplicationDbContext _context;
        public StudentRepository()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Students;
        }
        public Student GetById(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return _context.Students.SingleOrDefault(a => a.ID == id);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}