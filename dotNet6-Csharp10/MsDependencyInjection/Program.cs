using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DependencyInjection.Example;

class Program
{
    public static void Main(string[] args)
    {
        /*
         * The sample code registers the IMessageWriter service with the concrete type MessageWriter. 
         * The AddScoped method registers the service with a scoped lifetime, the lifetime of a single request. 
         * Service lifetimes are described later in this article.
         */
        var builder = Host.CreateDefaultBuilder(args);

        builder.ConfigureServices(
            services =>
                services
                    .AddHostedService<Worker>()  // Dependency Injection
                    .AddScoped<IMessageWriter, MessageWriter>());  // Dependency Injection


        var host = builder.Build();

        host.Run();
    }
}

public interface IMessageWriter
{
    void Write(string message);
}

public class MessageWriter : IMessageWriter
{
    public void Write(string message)
    {
        Console.WriteLine($"MessageWriter.Write(message: \"{message}\")");
    }
}

public class Worker : BackgroundService
{
    private readonly MessageWriter _messageWriter = new();

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _messageWriter.Write($"Worker running at: {DateTimeOffset.Now}");
            await Task.Delay(1000, stoppingToken);
        }
    }
}

