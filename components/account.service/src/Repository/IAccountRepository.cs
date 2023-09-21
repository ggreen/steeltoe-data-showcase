using System.Collections.Generic;
using steeltoe.data.showcase.Domain;

namespace steeltoe.data.showcase.Repository
{
    public interface IAccountRepository
    {
        void Save(Account value);

        List<Account> FindAll();

        Account FindById(int id);
        

         void DeleteById(int id);
    }
}