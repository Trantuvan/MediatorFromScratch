namespace MediatorFromScratch.Sample;

public class PrintToConsoleRequest : IRequest<bool>
{
    //* just get the text to print 
    //* use init to force initialization in ctor only
    public string Text { get; init; } = string.Empty;
}