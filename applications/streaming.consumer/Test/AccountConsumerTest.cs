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
using streaming.consumer.Consumer;

namespace streaming.consumer.test
{
    [TestClass]
    public class AccountConsumerTest
    {
        private Account account;
        private Mock<IServiceScope> serviceScope;
        private AccountConsumer subject;
        private Mock<IServiceProvider> serviceProvider;
        private Mock<ITestDataRepository> repository;

        [TestInitialize]
        public void InitializeAccountConsumerTest()
        {
            // repository = new Mock<ITestDataRepository>();

            // serviceProvider = new Mock<IServiceProvider>();
            // serviceProvider.Setup(sp => sp.GetRequiredService()).Returns(repository.Object);
            
            // serviceScope = new Mock<IServiceScope>();
            // serviceScope.Setup(ss => ss.ServiceProvider).Returns(serviceProvider.Object);
            
            // account = new Account();
            // subject = new AccountConsumer(serviceScope.Object);
        }

        [TestMethod]
        public void Accept()
        {
            // subject.Accept(account);

            // repository.Verify( repository => repository.Save(It.IsAny<Account>()));
        }
    }
}