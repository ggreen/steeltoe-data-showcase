using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Steeltoe.Extensions.Configuration.Placeholder;
using Steeltoe.Showcase.Caching.Sink.Consumers;
using Steeltoe.Stream.Extensions;
using Steeltoe.Extensions.Logging;
using Steeltoe.Extensions.Configuration;
using Steeltoe.Extensions.Configuration.ConfigServer;

namespace Steeltoe.Showcase.Caching.Sink
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                   .UseDefaultServiceProvider(options =>
                    options.ValidateScopes = false)
                .AddConfigServer()
                // .AddPlaceholderResolver()
                .ConfigureLogging((context, builder) => builder.AddDynamicConsole())
                .AddStreamServices<AccountConsumer>()
                .ConfigureWebHostDefaults(webBuilder => 
                { 
                    webBuilder.UseStartup<Startup>(); 
                    webBuilder.AddPlaceholderResolver();
                });
    
    }
}
