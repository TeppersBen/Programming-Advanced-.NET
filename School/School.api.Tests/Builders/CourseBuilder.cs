using School.Data.DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.api.Tests.Builders
{
    public class CourseBuilder
    {
        private Random _random;
        private Course _course;

        public CourseBuilder()
        {
            _random = new Random();
            _course = new Course
            {
                Title = Guid.NewGuid().ToString(),
                Credits = _random.Next(1, 11),
                DepartmentID = _random.Next(1, int.MaxValue)
            };
        }

        public CourseBuilder WithId()
        {
            _course.CourseID = _random.Next(1, int.MaxValue);
            return this;
        }

        public Course Build()
        {
            return _course;
        }
    }
}
