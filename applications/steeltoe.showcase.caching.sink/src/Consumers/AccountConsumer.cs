using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Showcase.SteelToe.Data.Solutions.Domain;
using Steeltoe.Showcase.Caching.Sink.Repository;
using Steeltoe.Stream.Attributes;
using Steeltoe.Stream.Messaging;

namespace Steeltoe.Showcase.Caching.Sink.Consumers
{
    [EnableBinding(typeof(ISink))]
    public class AccountConsumer
    {
        private IAccountRepository repository;

        public AccountConsumer(IAccountRepository repository)
        {
            this.repository = repository;
        }

        [StreamListener(ISink.INPUT)]
        public void Accept(Account account)
        {
            repository.Save(account);
        }
    }
}