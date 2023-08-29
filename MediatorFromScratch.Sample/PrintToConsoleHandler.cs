namespace MediatorFromScratch.Sample;

public class PrintToConsoleRequestHandler : IHandler<PrintToConsoleRequest, bool>
{
    // * the constructor of this handler will take in the service 
    // * that will turn PrintToConsoleRequest to bool
    // * serviceCollection.GetRequiredService will automatically resolve child dependencies for handler
    public Task<bool> HandleAsync(PrintToConsoleRequest request)
    {
        Console.WriteLine(request.Text);

        return Task.FromResult(true);
    }
}