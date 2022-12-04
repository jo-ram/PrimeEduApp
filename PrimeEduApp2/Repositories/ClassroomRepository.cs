using PrimeEduApp2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public Classroom StudentsPerClassroom(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return _context.Classrooms.Include(s => s.Students).SingleOrDefault(c => c.ID == id);
        }

        public Classroom ExercisesPerClassroom(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            return _context.Classrooms.Include(s => s.Exercises).SingleOrDefault(c => c.ID == id);
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

        public void Create(Classroom classroom)
        {
            _context.Classrooms.Add(classroom);
            _context.SaveChanges();
        }

        public void Update(Classroom classroom)
        {
            _context.Entry(classroom).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int? id)
        {
            var classroom = GetById(id);
            _context.Classrooms.Remove(classroom);
            _context.SaveChanges();
        }


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}