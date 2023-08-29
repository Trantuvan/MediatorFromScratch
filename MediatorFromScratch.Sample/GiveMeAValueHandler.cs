namespace MediatorFromScratch.Sample;

public class GiveMeAValueHandler : IHandler<GiveMeAValueRequest, string>
{
    public Task<string> HandleAsync(GiveMeAValueRequest request)
    {
        return Task.FromResult("Hello from Nick Mediator");
    }
}
