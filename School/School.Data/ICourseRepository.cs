using School.Data.DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Data
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetAll();
        Course Add(Course newCourse);
    }
}
