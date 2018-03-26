using System;
using System.Collections.Generic;
using System.Web.Http.Results;
using System.Web.Http.Routing;
using Moq;
using NUnit.Framework;
using OdeToFood.api.Data;
using OdeToFood.api.Data.DomainClasses;
using OdeToFood.Controllers;
using OdeToFood.Tests.Builders;

namespace OdeToFood.Tests.Controllers
{
    [TestFixture]
    public class RestaurantsControllerTest
    {
        private RestaurantsController _controller;
        private Mock<IRestaurantRepository> _repo;

        [SetUp]
        public void Setup()
        {
            _repo = new Moq.Mock<IRestaurantRepository>();
            _controller = new RestaurantsController(_repo.Object);
        }

        [Test]
        public void Get_ReturnsAllRestaurantsFromRepository()
        {
            var allRestaurants = new List<Restaurant>
            {
                new RestaurantBuilder().Build()
            };
            _repo.Setup(repo => repo.GetAll()).Returns(allRestaurants);

            var returnedRestaurants = _controller.Get();

            _repo.Verify(repo => repo.GetAll(), Times.Once);
            Assert.That(returnedRestaurants, Is.EquivalentTo(allRestaurants));
        }

        [Test]
        public void Get_ReturnsRestaurantlfltExists()
        {
            var restaurant = new RestaurantBuilder().Build();
            _repo.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(restaurant);

            var okResult = _controller.GetRestaurant(restaurant.Id) as OkNegotiatedContentResult<Restaurant>;

            Assert.That(okResult, Is.Not.Null);
            _repo.Verify(r => r.GetById(restaurant.Id), Times.Once);
            Assert.That(okResult.Content, Is.EqualTo(restaurant));
        }

        [Test]
        public void Get_ReturnsNotFoundlfltDoesNotExist()
        {
            _repo.Setup(r => r.GetById(It.IsAny<int>())).Returns(() => null);

            var notFoundResult = _controller.GetRestaurant(2) as NotFoundResult;

            Assert.That(notFoundResult, Is.Not.Null);
        }

        [Test]
        public void Post_ValidRestaurantIsSavedInRepository()
        {
            var restaurant = new Restaurant();
            _repo.Setup(repo => repo.Add(It.IsAny<Restaurant>())).Returns(() => {
                return restaurant;
            });

            var urlHelperMock = new Mock<UrlHelper>();
            urlHelperMock.Setup(u => u.Link(It.IsAny<string>(), It.IsAny<object>())).Returns(() => Guid.NewGuid().ToString());
            _controller.Url = urlHelperMock.Object;

            var actionResult = _controller.Post(restaurant) as CreatedAtRouteNegotiatedContentResult<Restaurant>;

            Assert.That(actionResult, Is.Not.Null);
            Assert.That(actionResult.Content.Id, Is.GreaterThan(0));
            Assert.That(actionResult.Content.Country, Is.EqualTo(restaurant.Country));
            Assert.That(actionResult.Content.City, Is.EqualTo(restaurant.City));
            Assert.That(actionResult.Content.Name, Is.EqualTo(restaurant.Name));

            urlHelperMock.Verify(u => u.Link("DefaultApi", It.IsAny<object>()), Times.Once);

            _repo.Verify(repo => repo.Add(restaurant), Times.Once);
        }

        [Test]
        public void Post_InValidRestaurantModelStateCausesBadRequest()
        {
            _controller.ModelState.AddModelError("Name", "Name is required");
            var badRequestResult = _controller.Post(new Restaurant { Name = "" }) as BadRequestResult;
            Assert.That(badRequestResult, Is.Not.Null);
            _repo.Verify(repo => repo.Add(It.IsAny<Restaurant>()), Times.Never);
        }

        [Test]
        public void Put_ExistingRestaurantIsSavedInRepository()
        {
            var aRestaurant = new RestaurantBuilder().Build();

            _repo.Setup(r => r.GetById(aRestaurant.Id)).Returns(() => aRestaurant);

            var okResult = _controller.Put(aRestaurant.Id, aRestaurant) as OkResult;

            Assert.That(okResult, Is.Not.Null);
            _repo.Verify(r => r.GetById(aRestaurant.Id), Times.Once);
            _repo.Verify(r => r.Update(aRestaurant), Times.Once);
        }

        [Test]
        public void Put_NonExistingRestaurantReturnsNotFound()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void Put_InValidRestaurantModelStateCausesBadRequest()
        {
            _controller.ModelState.AddModelError("Name", "name is required");

            var aRestaurant = new Restaurant { Name = "" };
            var badRequest = _controller.Put(aRestaurant.Id, aRestaurant);

            Assert.That(badRequest, Is.Not.Null);
            _repo.Verify(r => r.Update(It.IsAny<Restaurant>()), Times.Never);
        }

        [Test]
        public void Put_MismatchBetweenUrlIdAndRestaurantIdCausesBadRequest()
        {
            var restaurant = new Restaurant();
            var badRequest = _controller.Put(restaurant.Id, restaurant);

            _repo.Verify(r => r.Update(It.IsAny<Restaurant>()), Times.Never);
        }

        [Test]
        public void Delete_ExistingRestaurantIsDeletedFromRepository()
        {
            var restaurant = new Restaurant();
            _repo.Setup(r => r.GetById(restaurant.Id)).Returns(() => restaurant);
            var okResult = _controller.Delete(restaurant.Id) as OkResult;

            _repo.Verify(r => r.GetById(restaurant.Id), Times.Once);
            _repo.Verify(r => r.Delete(restaurant.Id), Times.Once);
        }

        [Test]
        public void Delete_NonExistingRestaurantsReturnNotFound()
        {
            throw new NotImplementedException();
        }
    }
}
