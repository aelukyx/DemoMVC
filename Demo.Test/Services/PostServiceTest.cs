using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Demo.Services.Services;
using Demo.Models.Models;
using Moq;
using System.Data.Entity;
using Demo.DB.DB;


namespace Demo.Test.Services
{
    [TestFixture]
    public class PostServiceTest
    {
        private Mock<DemoEntities> entitiesMock;

        [SetUp]
        public void SetUp()
        {
            //  Arrange 
            var db = PostFakeDB();
            var mockDbset = new Mock<IDbSet<Post>>();
            mockDbset.Setup(x => x.Provider).Returns(db.Provider);
            mockDbset.Setup(x => x.Expression).Returns(db.Expression);
            mockDbset.Setup(x => x.ElementType).Returns(db.ElementType);
            mockDbset.Setup(x => x.GetEnumerator()).Returns(db.GetEnumerator);
            entitiesMock = new Mock<DemoEntities>();
            entitiesMock.Setup(x => x.Posts).Returns(mockDbset.Object);
        }

        [Test]
        public void TestAllReturnIListPost()
        { 
            var service = new PostService(entitiesMock.Object);

            var result = service.All();

            Assert.IsInstanceOf(typeof(IList<Post>), result);
            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public void TestGetByIdReturnPostIsOk()
        {           

            var service = new PostService(entitiesMock.Object);

            var result = service.GetById(1);

            Assert.AreEqual("My First Post", result.Title);
            Assert.AreEqual("Lorem ipsum", result.Body);
        }


        [Test]
        public void TestInsertCreateNewRow() {
            
            var service = new PostService(entitiesMock.Object);

            service.Insert(new Post { Title = "Tercer Post", Body = "Lorem ipsum"});            
        }


        private IQueryable<Post> PostFakeDB()
        {
            return new List<Post>
            {
                new Post { Id = 1, Title = "My First Post", Body = "Lorem ipsum"},
                new Post { Id = 2, Title = "My Second Post", Body = "Lorem ipsum"},
            }.AsQueryable();
        }
    }
}
