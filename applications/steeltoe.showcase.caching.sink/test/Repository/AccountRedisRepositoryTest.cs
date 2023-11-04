using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Showcase.SteelToe.Data.Solutions.Domain;
using StackExchange.Redis;
using Steeltoe.Showcase.Caching.Sink.Repository;

namespace Steeltoe.Showcase.Caching.Sink.test.Repository
{
    [TestClass]
    public class AccountRedisRepositoryTest
    {
        private AccountRedisRepository subject;
        private Mock<IConnectionMultiplexer> connection;
        private Mock<IDatabase> database;
        private Account account;
        private TimeSpan? expiry = null;
        private StackExchange.Redis.When aWhen = When.Always;
        private CommandFlags flags = CommandFlags.None;

        [TestInitialize]
        public void InitializeAccountRedisRepositoryTest()
        {
            account = new Account();

            connection = new Mock<IConnectionMultiplexer>();
            database = new Mock<IDatabase>();

            connection.Setup( c => c.GetDatabase(It.IsAny<Int32>(),It.IsAny<object>())).Returns(database.Object);

            subject = new AccountRedisRepository(connection.Object);
        }

        [TestMethod]
        public void Save()
        {
  
            subject.Save(account);

            database.Verify(database => database.StringSet(
                It.IsAny<RedisKey>(), 
                It.IsAny<RedisValue>(), 
               expiry,
                aWhen,
                flags));

        }
    }
}