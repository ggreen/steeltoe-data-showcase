using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using steeltoe.data.showcase.Domain;
using steeltoe.data.showcase.Repository;
using Microsoft.EntityFrameworkCore;
using Imani.Solutions.Core.API.Util;

namespace steeltoe.data.showcase.Repository
{
    public class TestDataRepository : ITestDataRepository
    {
        private SampleContext dbContext;
        private readonly int findAllLimit = new ConfigSettings().GetPropertyInteger("findAllLimit",1000);

        public TestDataRepository(SampleContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Save(Account testData)
        {
            var updateData = FindById(testData.Id);

            if(updateData == null)
                dbContext.Add(testData);
            else
                updateData.Data = testData.Data;

            dbContext.SaveChanges();
        }

        public Account FindById(int id)
        {
            return dbContext.Find<Account>(id);
        }

        public void DeleteById(int keyId)
        {
            var deleteRecord = FindById(keyId);
            if(deleteRecord == null)
                return;

            dbContext.Remove(deleteRecord);
            dbContext.SaveChanges();
        }

        public List<Account> FindAll()
        {
           return  dbContext.Account.Select(x => x)
           .Take(findAllLimit)
           .OrderBy( x => x.Id).ToList();
        }
    }
}