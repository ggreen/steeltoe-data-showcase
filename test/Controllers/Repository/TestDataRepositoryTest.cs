using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using steeltoe.data.showcase.Domain;
using steeltoe.data.showcase.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace steeltoe.data.showcase.test.Controllers.Repository
{
    [TestClass]
    public class TestDataRepositoryTest
    {
        private SampleContext dbContext;
        private TestDataRepository subject;
        // private Moq.EntityFrameworkCore.<SampleContext> dbContext;
        private DbContextOptions options;
        private TestData testData;

        [TestInitialize]
        public void InitializeTestDataEfcRepositoryTest()
        {
             options =  new DbContextOptionsBuilder<SampleContext>()
            .UseInMemoryDatabase(databaseName: "SampleDatabase")
            .Options;

            dbContext = new SampleContext(options);

            subject = new TestDataRepository(dbContext);

            testData = new TestData();
        }

        [TestMethod]
        public void TestSaveData()
        {
            subject.Save(testData);
            var actual = subject.FindById(testData.Id);

            Assert.AreEqual(testData.Id, actual.Id);
        }

         [TestMethod]
        public void UpdateData()
        {
            var testDataUpdate = new TestData();
            testData.Id = 2;
            testData.Data = "test update";

            subject.Save(testData);

            subject.Save(testData);
        }

        [TestMethod]
        public void TestDelete()
        {

            var testDataUpdate = new TestData();
            testData.Id = 3;
            testData.Data = "test update";

            subject.Save(testData);

             var actual = subject.FindById(testData.Id);

            Assert.AreEqual(testData.Id, actual.Id);

            subject.DeleteById(testData.Id);

            Assert.IsNull(subject.FindById(testData.Id));
        }

         [TestMethod]
        public void TestFindAll()
        {

            var testDataUpdate = new TestData();
            testData.Id = 4;
            testData.Data = "test update";

            subject.Save(testData);

             var actual = subject.FindAll();

            Assert.IsNotNull(actual);
        }
    }
}