using Demo.Controllers;
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

            
            var controller = new PostController(null);

            // Act

            var view = controller.Index() as ViewResult;


            //Assert

            Assert.IsNotNull(view);
            Assert.AreEqual("Index", view.ViewName);
        }
    }
}
