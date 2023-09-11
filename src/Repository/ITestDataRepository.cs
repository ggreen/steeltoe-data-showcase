using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using steeltoe.data.showcase.Domain;

namespace steeltoe.data.showcase.Repository
{
    public interface ITestDataRepository
    {
        void Save(Account value);

        List<Account> FindAll();

        Account FindById(int id);
        

         void DeleteById(int id);
    }
}