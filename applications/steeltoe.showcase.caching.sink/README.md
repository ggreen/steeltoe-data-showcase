# Steeltoe Showcase Caching Sink

This project provides an example for a [SteelToe](https://steeltoe.io/) application that 
uses [GemFire for Redis Apps](https://tanzu.vmware.com/content/blog/introducing-vmware-tanzu-gemfire-for-redis-apps).


The Account Consumer using [SteelToe Stream](https://docs.steeltoe.io/api/v3/stream/stream-reference.html).
This provides a simple development experience to implement a consumer for [RabbitMQ](https://rabbitmq.com/). 

```c#
EnableBinding(typeof(ISink))]
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
```


The AccountRedisRepository is autowired a IConnectionMultiplexer connection by
the [SteelToe Redis connector](https://docs.steeltoe.io/api/v3/connectors/redis.html).

```c#
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
```


This project also demstrates using [SteelToe's configuration 
support with Spring Cloud Config Server](https://docs.steeltoe.io/api/v3/configuration/config-server-provider.html).


The following is an example 
account-redis-sink.properties

```yaml
spring.cloud.stream.bindings.input.destination: account-steeltoe
```