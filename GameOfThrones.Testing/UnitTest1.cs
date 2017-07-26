using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameOfThrones.Controllers;
using GameOfThrones.Repository;
using GameOfThrones.Repository.Models;
using Moq;

namespace GameOfThrones.Testing
{
    [TestClass]
    public class UnitTest1
    {


        [TestMethod]
        public void TestMethod1()
        {
            var data = new List<House>()
            {
                new House()
                {
                    HouseName = "Stark",
                    People = new List<Person>()
                    {
                        new Person() {Name = "Ned"}
                    }
                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<House>>();
            mockSet.As<IQueryable<House>>().Setup(x => x.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<House>>().Setup(x => x.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<House>>().Setup(x => x.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<House>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<GotContext>();
            mockContext.Setup(m => m.Houses).Returns(mockSet.Object);

            var unitOfWorkMock = new UnitOfWork(mockContext.Object);


            HomeController controller = new HomeController(unitOfWorkMock);

            var result = controller.Read() as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.ViewData["Houses"]);
        }
    }
}
