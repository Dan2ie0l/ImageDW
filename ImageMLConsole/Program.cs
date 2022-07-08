// See https://aka.ms/new-console-template for more information
using ImageMLConsole.Sevices;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

Console.WriteLine("Hello, World!");

var serviceProvider = new ServiceCollection()
           .AddLogging()
           .AddMediatR(typeof(Program))
           .AddSingleton<IScrapeingService, ScrapingService>()
           .AddSingleton<ApplicationStartupService>()
           .BuildServiceProvider();

//configure console logging
/*serviceProvider
    .GetService<ILoggerFactory>()
    .AddConsole(LogLevel.Debug);

var logger = serviceProvider.GetService<ILoggerFactory>()
    .CreateLogger<Program>();
logger.LogDebug("Starting application");*/
serviceProvider.GetService<ApplicationStartupService>().Start().GetAwaiter().GetResult();
