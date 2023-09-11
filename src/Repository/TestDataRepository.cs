using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using steeltoe.data.showcase.Domain;
using steeltoe.data.showcase.Repository;
using Microsoft.EntityFrameworkCore;

namespace steeltoe.data.showcase.Repository
{
    public class TestDataRepository : ITestDataRepository
    {
        private SampleContext dbContext;

        public TestDataRepository(SampleContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Save(TestData testData)
        {
            var updateData = FindById(testData.Id);

            if(updateData == null)
                dbContext.Add(testData);
            else
                updateData.Data = testData.Data;

            dbContext.SaveChanges();
        }

        public TestData FindById(int id)
        {
            return dbContext.Find<TestData>(id);
        }

        public void DeleteById(int keyId)
        {
            var deleteRecord = FindById(keyId);
            if(deleteRecord == null)
                return;

            // dbContext.Attach(deleteRecord);
            dbContext.Remove(deleteRecord);
            dbContext.SaveChanges();
        }

        public List<TestData> FindAll()
        {
           return  dbContext.TestData.Select(x => x).ToList();
        }
    }
}