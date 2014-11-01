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
            AssertViewsWithModel(view, "Index");
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
            AssertViewsWithModel(view, "Details");
            Assert.IsInstanceOf(typeof(Post), view.Model);
        }

        [Test]
        public void TestCreateReturnViewIsOk()
        {
            var controller = new PostController(null);

            var view = controller.Create() as ViewResult;

            AssertViewWithoutModel(view, "Create");

        }

        [Test]
        public void TestPostGuardadoCorrectamenteRedirectToIndex()
        {
            var mock = new Mock<IPostService>();
            var controller = new PostController(mock.Object);

            var redirect = controller.Create(new Post { Title = "Mi First Post"}) as RedirectToRouteResult;

            Assert.IsNotNull(redirect);
            Assert.AreEqual("Index", redirect.RouteValues["action"]);
        }

        [Test]
        public void TestPostValicacionFallaReturnViewCreate()
        {
            var mock = new Mock<IPostService>();
            var controller = new PostController(mock.Object);

            var view = controller.Create(new Post()) as ViewResult;

            AssertViewsWithModel(view, "create");
            Assert.IsInstanceOf(typeof(Post), view.Model);

        }

        [Test]
        public void TestEditReturnViewIsOk()
        {
            var mock = new Mock<IPostService>();
            mock.Setup(x => x.GetById(1)).Returns(new Post()) ;

            var controller = new PostController(mock.Object);

            var view = controller.Edit(1) as ViewResult;

            AssertViewsWithModel(view, "edit");
            mock.Verify(x=>x.GetById(1),Times.Exactly(1));
           
        }
        [Test]
        public void TestEditEditGuardoCorrectamente()
        {
            //arrange
            var mock = new Mock<IPostService>();
            var controller = new PostController(mock.Object);

            var redirect = controller.Edit(new Post { Title= "Post MIDIFICADO"}) as RedirectToRouteResult;

            Assert.IsNotNull(redirect);
            Assert.AreEqual("Index", redirect.RouteValues["action"]);
        }

        [Test]
        public void TestEditCuandoValidacionFallaRetronaVistaEdit()
        {
            var controller = new PostController(null);

            var view = controller.Edit(new Post()) as ViewResult;

            AssertViewsWithModel(view, "Edit");
            
        }


        private void AssertViewsWithModel(ViewResult view, string viewName)
        {
            Assert.IsNotNull(view, "Vista no puede ser nulo");
            Assert.AreEqual(viewName, view.ViewName);
            Assert.IsNotNull(view.Model);
        }

        private void AssertViewWithoutModel(ViewResult view, string viewName)
        {
            Assert.IsNotNull(view);
            Assert.AreEqual(viewName, view.ViewName);
            Assert.IsNull(view.Model);
        }
    }
}
