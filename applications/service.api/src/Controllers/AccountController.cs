using System.Collections.Generic;
using steeltoe.data.showcase.Domain;
using steeltoe.data.showcase.Repository;
using Microsoft.AspNetCore.Mvc;

namespace steeltoe.data.showcase.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController
    {
        private IAccountRepository repository;

        public AccountController(IAccountRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public void PostData(Account testData)
        {
            this.repository.Save(testData);
        }

        [HttpGet]
          [Route("{id}")] 
        public Account FindById(int id)
        {
            
            return this.repository.FindById(id);
        }

       [HttpGet]
        public List<Account> FindAll()
        {
            return this.repository.FindAll();
        }

        [HttpDelete]
         [Route("{id}")] 
        public void DeleteById(int id)
        {
            this.repository.DeleteById(id);
        }
    }
}