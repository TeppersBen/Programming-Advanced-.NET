using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        [Test]
        public void Get_ReturnsNotFoundlfltDoesNotExist()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void Post_ValidRestaurantIsSavedInRepository()
        {
            var restaurant = new Restaurant();
            _controller.Post(restaurant);
            _repo.Verify(repo => repo.Add(restaurant));
        }

        [Test]
        public void Post_InValidRestaurantModelStateCausesBadRequest()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void Put_ExistingRestaurantIsSavedInRepository()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void Put_NonExistingRestaurantReturnsNotFound()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void Put_InValidRestaurantModelStateCausesBadRequest()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void Put_MismatchBetweenUrlIdAndRestaurantIdCausesBadRequest()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void Delete_ExistingRestaurantIsDeletedFromRepository()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void Delete_NonExistingRestaurantsReturnNotFound()
        {
            throw new NotImplementedException();
        }
    }
}
