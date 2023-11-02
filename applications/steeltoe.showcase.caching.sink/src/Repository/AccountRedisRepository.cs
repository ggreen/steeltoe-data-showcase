using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Showcase.SteelToe.Data.Solutions.Domain;
using StackExchange.Redis;

namespace Steeltoe.Showcase.Caching.Sink.Repository
{
    public class AccountRedisRepository : IAccountRepository
    {
        private readonly IConnectionMultiplexer connection;
        private readonly IDatabase database;

        public AccountRedisRepository(IConnectionMultiplexer connection){
            this.connection = connection;

            this.database = this.connection.GetDatabase();
        }

        public void Save(Account account)
        {
            this.database.StringSet(account.Id.ToString(),JsonSerializer.Serialize(account));            
        }
    }
}