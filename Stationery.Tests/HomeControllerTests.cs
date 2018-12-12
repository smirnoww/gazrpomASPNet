using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Moq;
using StationeryProject.Controllers;
using StationeryProject.Models;
using Xunit;


namespace Stationery.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void IndexViewResultNotNull()
        {
            // TODO: реализовать в mock классе IQuerable для LINQ запросов
            // Arrange
            var mock = new Mock<StationeryContext>();

            SprUser user = new SprUser();
            user.LastName = "Sidorov";
            user.FirstName = "Ivan";
            user.Id = 100;
            mock.Setup(db => db.SprUser.Add(user));

            SprProduct prod = new SprProduct();
            prod.ProductName = "karandash";
            prod.Id = 101;
            mock.Setup(db => db.SprProduct.Add(prod));

            HomeController controller = new HomeController(mock.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void IndexViewResultNotNull2()
        {

            StationeryContext sc = new StationeryContext();
            HomeController controller = new HomeController(sc);
            // Act
            ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void AddRequest()
        {
            // Arrange
            StationeryContext sc = new StationeryContext();
            HomeController controller = new HomeController(sc);

            UserProductRequest upr = new UserProductRequest();
            upr.ProductId = 1;
            upr.UserId = 1;
            upr.ProductAmount = 1;

            // Act
            ViewResult result = controller.AddRequest(upr) as ViewResult;

            // Assert
            Assert.IsType<ViewResult>(result);
        }

    }
}
