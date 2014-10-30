using System.Collections.Generic;
using Demo.Controllers;
using Demo.Interfaces.Services;
using Demo.Models.Models;
using Demo.Services.Services;
using Moq;
using NUnit.Framework;
using System.Web.Mvc;

namespace Demo.Test.Controllers
{
    [TestFixture]
    public class PostControllerTest
    {

        [Test]
        public void TestIndexReturnViewIsOk()
        {
            //Arrange
            var mock = new Mock<IPostService>();
            mock.Setup(x => x.All()).Returns(new List<Post>());
            var controller = new PostController(mock.Object);

            // Act

            var view = controller.Index();

            //Assert
            mock.Verify(x => x.All(), Times.Once);
            Assert.IsNotNull(view);
            Assert.AreEqual("Index", view.ViewName);
            Assert.IsNotNull(view.Model);
            Assert.IsInstanceOf(typeof (List<Post>), view.Model);
        }

        [Test]
        public void TestDetailsRedirectToIndexWhenIdIsZero()
        {
            // Arrange

            var controller = new PostController(null);

            // Act

            var redirect = controller.Details(0) as RedirectToRouteResult;

            //Assert
            Assert.IsNotNull(redirect);
            Assert.AreEqual("Index", redirect.RouteValues["action"]);
        }

        [Test]
        public void TestDetailsreturnViewIsOk()
        {
            // Arrange
            var mock = new Mock<IPostService>();
            mock.Setup(x => x.GetById(1)).Returns(new Post { });
            var controller = new PostController(mock.Object);

            // Act

            var view = controller.Details(1) as ViewResult;

            //Assert
            Assert.IsNotNull(view);
            Assert.AreEqual("Details", view.ViewName);
            Assert.IsNotNull(view.Model);
            Assert.IsInstanceOf(typeof(Post), view.Model);
        }
    }
}
