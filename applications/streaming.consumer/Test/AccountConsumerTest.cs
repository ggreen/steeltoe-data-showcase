using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using steeltoe.data.showcase.Domain;

namespace streaming.consumer.Test
{
    [TestClass]
    public class AccountConsumerTest
    {
        private Account account;
        private Mock< repository;

        [TestMethod]
        public void TestMethod1()
        {
            subject.Accept(account);

            repository.Verify( repository => repository.Save(It.IsAny<Account>()));
            Assert.IsTrue(true);
        }
    }
}