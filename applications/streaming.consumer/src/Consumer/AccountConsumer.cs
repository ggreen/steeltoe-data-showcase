using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using steeltoe.data.showcase.Domain;
using steeltoe.data.showcase.Repository;
using Steeltoe.Stream.Attributes;
using Steeltoe.Stream.Messaging;

namespace streaming.consumer.Consumer
{
    [EnableBinding(typeof(ISink))]
    public class AccountConsumer
    {

         private readonly ILogger log;

        public delegate ITestDataRepository CreateRepository();

        private CreateRepository repositoryCreator;

        public AccountConsumer(IServiceProvider serviceProvider)
        : this(delegate {
            return serviceProvider.GetRequiredService<ITestDataRepository>();
        })
        {}

        public AccountConsumer(CreateRepository repositoryCreator)
        {
            this.repositoryCreator = repositoryCreator;
            // this.log = log;
        }

        [StreamListener(ISink.INPUT)]
        public void Accept(Account account)
        {
            Console.WriteLine($"ACCOUNT: ${account}");

            var repository = repositoryCreator();

            repository.Save(account);
        }
    }
}