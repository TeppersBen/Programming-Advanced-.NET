using System;
using Moq;
using NUnit.Framework;
using OdeToFood.api.Data;
using OdeToFood.api.Data.DomainClasses;
using OdeToFood.Controllers;

namespace OdeToFood.Tests.Controllers
{
    [TestFixture]
    public class RestaurantsControllerTest
    {
        private RestaurantsController _restaurantsController;

        [SetUp]
        public void Setup()
        {
            _restaurantsController = new RestaurantsController();
        }

        [Test]
        public void Get_ReturnsAllRestaurantsFromRepository()
        {
            var repo = new Mock<IRestaurantRepository>();
            
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
            throw new NotImplementedException();
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
