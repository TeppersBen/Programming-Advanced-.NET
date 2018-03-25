using School.Data;
using School.Data.DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace School.api.Controllers
{
    public class CoursesController : ApiController
    {
        private readonly ICourseRepository _courseRepository;

        //Constructor
        public CoursesController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        // GET: api/Courses
        public IEnumerable<Course> Get()
        {
            return _courseRepository.GetAll();
        }

        // api/courses
        public IHttpActionResult Post([FromBody] Course newCourse)
        {
            var createdCourse = _courseRepository.Add(newCourse);
            var courseUrl = Url.Link("DefaultApi", new { controller = "Courses", id=createdCourse.CourseID});
            return Created(courseUrl, createdCourse);           
        }

        // api/course/5
        public IHttpActionResult GetById(int id)
        {
            if (id == 1)
            {
                var course = new Course
                {
                    CourseID = 1,
                    Title = "Some course"
                };
                return Ok(course);
            }
            return NotFound();
        }

        // api/courses/5/department
        [Route("api/courses/{id}/department")]
        public string GetCourseDepartment(int id)
        {
            return "DepartmentOfCourse";
        }
    }
}
