using System;
using System.Collections.Generic;
using System.Web.Http.Results;
using System.Web.Http.Routing;
using Moq;
using NUnit.Framework;
using School.api.Controllers;
using School.api.Tests.Builders;
using School.Data;
using School.Data.DomainClasses;

namespace School.api.Tests.Controllers
{
    [TestFixture]
    public class CoursesControllerTest
    {
        private Mock<ICourseRepository> _coursesRepositoryMock;
        private CoursesController _controller;

        // Duplication in mocks
        [SetUp]
        public void Setup()
        {
            _coursesRepositoryMock = new Moq.Mock<ICourseRepository>();
            _controller = new CoursesController(_coursesRepositoryMock.Object);
        }


        [Test]
        public void Get_ReturnsAllCoursesFromRepository()
        {
            // Arrange
            var allCourses = new List<Course>
            {
                new CourseBuilder().WithId().Build()
            };
            _coursesRepositoryMock.Setup(repo => repo.GetAll()).Returns(allCourses);
            

            // Act
            var returnedCourses = _controller.Get();

            // Assert
            _coursesRepositoryMock.Verify(repo => repo.GetAll(), Times.Once);
            Assert.That(returnedCourses, Is.EquivalentTo(allCourses));

        }

        [Test]
        public void Post_ValidCourseIsSavedInRepository()
        {
            // Arrange
            var newCourse = new CourseBuilder().Build();
            _coursesRepositoryMock.Setup(repo => repo.Add(It.IsAny<Course>())).Returns(() =>
            {
                newCourse.CourseID = new Random().Next(1, int.MaxValue);
                return newCourse;
            });

            var urlHelperMock = new Mock<UrlHelper>();
            urlHelperMock.Setup(helper => helper.Link(It.IsAny<string>(), It.IsAny<object>())).Returns(() => Guid.NewGuid().ToString());
            _controller.Url = urlHelperMock.Object;

            // Act
            var actionResult = _controller.Post(newCourse) as CreatedNegotiatedContentResult<Course>;

            // Assert
            Assert.That(actionResult, Is.Not.Null);
            Assert.That(actionResult.Content.CourseID, Is.GreaterThan(0));
            Assert.That(actionResult.Content.Title, Is.EqualTo(newCourse.Title));
            _coursesRepositoryMock.Verify(repo => repo.Add(newCourse), Times.Once);

            urlHelperMock.Verify(helper => helper.Link("DefaultApi", It.IsAny<object>()), Times.Once);
        }
    }

    
}
