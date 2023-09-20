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

        private readonly IServiceProvider serviceProvider;
         private readonly ILogger log;

        public AccountConsumer(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            // this.log = log;
        }

        [StreamListener(ISink.INPUT)]
        public void Accept(Account account)
        {
            Console.WriteLine($"ACCOUNT: ${account}");

            var repository = serviceProvider.GetRequiredService<ITestDataRepository>();

            repository.Save(account);
        }
    }
}