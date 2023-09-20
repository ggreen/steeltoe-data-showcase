using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using steeltoe.data.showcase.Domain;
using steeltoe.data.showcase.Repository;
using Steeltoe.Integration.Rabbit.Support;
using streaming.consumer.Consumer;

namespace streaming.consumer.test
{
    [TestClass]
    public class AccountConsumerTest
    {
        private Account account;
        
        
        private Mock<ITestDataRepository> repository;

        private AccountConsumer subject;

        [TestInitialize]
        public void InitializeAccountConsumerTest()
        {
            repository = new Mock<ITestDataRepository>();

            account = new Account();
            subject = new AccountConsumer(
                            delegate (){
                                return repository.Object;
                            });
        }

        [TestMethod]
        public void Accept()
        {
            subject.Accept(account);

            repository.Verify( repository => repository.Save(It.IsAny<Account>()));
        }
    }
}