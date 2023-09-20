using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Steeltoe.Common.Hosting;
using Steeltoe.Extensions.Logging;
using Steeltoe.Stream.Extensions;
using streaming.consumer.Consumer;

namespace steeltoe.streaming.consumer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
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
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}
