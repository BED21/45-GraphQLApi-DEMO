using HotChocolate.Resolvers;

using static Api.Mutation;

namespace Api;
public class DomainExceptionMiddleware
{
    private readonly FieldDelegate _next;

    public DomainExceptionMiddleware(FieldDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(IMiddlewareContext context)
    {
        try
        {
            await _next(context);
        }
        catch (DomainException ex) when (SetResult(context, ex.Message))
        {
        }
    }

    private bool SetResult(IMiddlewareContext context, string message)
    {
        Type type = context.Selection.Field.Type.NamedType().ToRuntimeType();

        if (type.IsSubclassOf(typeof(Payload)))
        {
            context.Result = (Payload)Activator.CreateInstance(type, null, message)!;

            return true;
        }
        return false;
    }
}
