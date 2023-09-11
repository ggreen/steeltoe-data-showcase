using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using steeltoe.data.showcase.Controllers;
using steeltoe.data.showcase.Domain;
using steeltoe.data.showcase.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace steeltoe.data.showcase.test.Controllers
{
    [TestClass]
    public class TestDataControllerTest
    {

        private Mock<ITestDataRepository> repository = new Mock<ITestDataRepository>();
        private TestDataController subject;
        private TestData testData;

        [TestInitialize]
        public void InitializeTestDataController()
        {
            repository = new Mock<ITestDataRepository>();
            subject = new TestDataController(repository.Object);
            testData = new TestData();
            testData.Id = 1;
        }
        
        [TestMethod]
        public void SaveData()
        {
            subject.PostData(testData);

            repository.Verify( repository => repository.Save(It.IsAny<TestData>()));
        }

        [TestMethod]
        public void FindData()
        {
            repository.Setup( r => r.FindById(1)).Returns(testData);
            Assert.AreEqual(testData,subject.FindById(testData.Id));
            
        }

          [TestMethod]
        public void FindAll()
        {
            
            List<TestData> expected = new List<TestData>();
            expected.Add(testData);

            repository.Setup( r => r.FindAll()).Returns(expected);

            Assert.AreEqual(expected,subject.FindAll());
            
        }


          [TestMethod]
        public void DeleteById()
        {
            subject.DeleteById(1);

            repository.Verify( repository => repository.DeleteById(It.IsAny<int>()));
            
        }
    }
}