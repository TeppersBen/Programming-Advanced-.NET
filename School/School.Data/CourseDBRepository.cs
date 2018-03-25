using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using School.Data.DomainClasses;

namespace School.Data
{
    public class CourseDBRepository : ICourseRepository
    {
        private readonly SchoolDB _context;

        public CourseDBRepository(SchoolDB context)
        {
            _context = context;
        }

        public Course Add(Course newCourse)
        {
            _context.Courses.Add(newCourse);
            _context.SaveChanges();
            return _context.Courses.Include(c => c.Department).FirstOrDefault(c => c.CourseID == newCourse.CourseID);
            // return newCourse;
        }

        public IEnumerable<Course> GetAll()
        {
            return _context.Courses.Include(c => c.Department).ToList();
        }
    }
}
