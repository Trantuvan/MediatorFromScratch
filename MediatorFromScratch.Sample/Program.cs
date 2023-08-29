using MediatorFromScratch;
using MediatorFromScratch.Sample;
using Microsoft.Extensions.DependencyInjection;

//* request
//* handler
//* mediator
//* request -> handler figure out what handler reacts to return a response
internal class Program
{
    private static async Task Main(string[] args)
    {
        var serviceProviders = new ServiceCollection()
            .AddTransient<PrintToConsoleRequestHandler>()
            .BuildServiceProvider();

        PrintToConsoleRequest request = new() { Text = "Hello from Mediator" };

        var handlerDetails = new Dictionary<Type, Type>
        {
            {typeof(PrintToConsoleRequest), typeof(PrintToConsoleRequestHandler)}
        };

        //* call Mediator and pass in a function to get the type which is registered
        //* to serviceCollection and resolve to type Object
        IMediator mediator = new Mediator(serviceProviders.GetRequiredService, handlerDetails);

        await mediator.SendAsync(request);
    }
}