using DockerDemo.Shared;
using MassTransit;

namespace DockerDemo.Subscriber.Handlers;

public record ItemCreatedHandler : IConsumer<IteamCreated>
{


    public Task Consume(ConsumeContext<IteamCreated> context)
    {
        Console.WriteLine(
            $"Item '{context.Message.Id}' " +
            $"with price '{context.Message.Message}' created.");

        return Task.CompletedTask;
    }
}
