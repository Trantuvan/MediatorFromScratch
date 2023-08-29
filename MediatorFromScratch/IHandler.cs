namespace MediatorFromScratch;

//* IHandler takes in TRequest return TResponse
//* where TRequest is(implemented) IRequest return TResponse
public interface IHandler<in TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    Task<TResponse> HandleAsync(TRequest request);
}