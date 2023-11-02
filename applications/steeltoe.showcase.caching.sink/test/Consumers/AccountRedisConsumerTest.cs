using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Showcase.SteelToe.Data.Solutions.Domain;
using Steeltoe.Showcase.Caching.Sink.Consumers;
using Steeltoe.Showcase.Caching.Sink.Repository;

namespace Steeltoe.Showcase.Caching.Sink.test.Consumers
{
    [TestClass]
    public class AccountRedisConsumerTest
    {
        private AccountConsumer subject;
        private Mock<IAccountRepository> repository;
        

        [TestInitialize]
        public void InitializeAccountRedisConsumerTest()
        {
            repository = new Mock<IAccountRepository>();
            subject = new AccountConsumer(repository.Object);
        }

        [TestMethod]
        public void Accept()
        {
            Account input = null;
            subject.Accept(input);

            repository.Verify( repository => repository.Save(It.IsAny<Account>()));
            
        }
    }
}