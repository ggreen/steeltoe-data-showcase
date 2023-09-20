using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using steeltoe.data.showcase.Repository;
using Steeltoe.Common.Hosting;
using Steeltoe.Extensions.Configuration.Placeholder;
using Steeltoe.Extensions.Logging;
using Steeltoe.Stream.Extensions;
using streaming.consumer.Consumer;

namespace steeltoe.streaming.consumer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

                  //Run migration
            using (var scope = host.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<SampleContext>();
                
                 SampleContext.Migrate(db.Database);
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseCloudHosting(58628)
                .UseDefaultServiceProvider(options =>
                    options.ValidateScopes = false)
                .ConfigureLogging((builderContext, loggingBuilder) =>
                {
                    // Add Steeltoe Dynamic Logging provider
                    loggingBuilder.AddDynamicConsole();
                })
                
                .ConfigureLogging((context, builder) => builder.AddDynamicConsole())
                .AddStreamServices<AccountConsumer>()
                .ConfigureWebHostDefaults(webBuilder => 
                { 
                    webBuilder.UseStartup<Startup>(); 
                    webBuilder.AddPlaceholderResolver();
                });
    }
}
