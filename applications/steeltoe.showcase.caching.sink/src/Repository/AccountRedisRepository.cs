using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
        private const string KEY_PREFIX = "Accouunt|";

        public AccountRedisRepository(IConnectionMultiplexer connection){
            this.connection = connection;

            this.database = this.connection.GetDatabase();
        }

        public void Save(Account account)
        {
            this.database.StringSet($"{KEY_PREFIX}{account.Id}",JsonSerializer.Serialize(account));            
        }
    }
}