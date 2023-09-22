using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using steeltoe.data.Showcase.Domain;
using steeltoe.data.Showcase.Repository;
using streaming.consumer.Consumer;

namespace streaming.consumer.test
{
    [TestClass]
    public class AccountConsumerTest
    {
        private Account account;
        
        
        private Mock<IAccountRepository> repository;
        private Mock<ILogger<AccountConsumer>>  log;

        private AccountConsumer subject;

        [TestInitialize]
        public void InitializeAccountConsumerTest()
        {
            log = new Mock<ILogger<AccountConsumer>>();
            repository = new Mock<IAccountRepository>();

            account = new Account();
            subject = new AccountConsumer(
                            delegate (){
                                return repository.Object;
                            },
                            log.Object);
        }

        [TestMethod]
        public void Accept()
        {
            subject.Accept(account);

            repository.Verify( repository => repository.Save(It.IsAny<Account>()));
        }
    }
}