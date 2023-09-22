using System.Collections.Generic;
using steeltoe.data.Showcase.Domain;

namespace steeltoe.data.Showcase.Repository
{
    public interface IAccountRepository
    {
        void Save(Account value);

        List<Account> FindAll();

        Account FindById(int id);
        

         void DeleteById(int id);
    }
}