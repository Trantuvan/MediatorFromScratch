namespace MediatorFromScratch;

public class Mediator : IMediator
{
    //* using DI to obtain all services that are needed for communication
    //* Delegate methods taking a type obj return an instance of object
    private readonly Func<Type, object> _serviceResolver;

    //* to keep track of all things can handle
    //* dictionary store elements to map from one Type to another Type
    private readonly IDictionary<Type, Type> _handlerDetails;

    public Mediator(Func<Type, object> serviceResolver, IDictionary<Type, Type> handlerDetails)
    {
        _serviceResolver = serviceResolver;
        //* initialize ConcurrentDictionary pass in IDictionary
        _handlerDetails = handlerDetails;
    }

    public async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
    {
        var requestType = request.GetType();

        if (!_handlerDetails.ContainsKey(requestType))
        {
            throw new ArgumentException("No handler to handle request of type", nameof(requestType));
        }

        //* get type of handler from dictionary
        _handlerDetails.TryGetValue(requestType, out var handlerRequestType);

        //* initialize handler
        var handler = _serviceResolver(handlerRequestType!);

        // Cannot cast a type to a Generic type with generic parameter
        //compile time will be fine, at runtime will get error
        // MediatorFromScratch.IHandler`2[MediatorFromScratch.IRequest`1
        // [System.Boolean],System.Boolean]'.
        // `1 & `2 here are generic type


        //return await ((IHandler<IRequest<TResponse>, TResponse>)handler).HandleAsync(request);

        return await (Task<TResponse>)handler.GetType()
                                             .GetMethod("HandleAsync")!
                                             .Invoke(handler, new[] { request })!;
    }
}
