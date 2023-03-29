using MediatR;
using TRIMANA.Customer.Domain.Messages.Responses.Base;

namespace TRIMANA.Customer.Domain.Messages.Requests.Base
{
    public class RequestBase<TResponse> : IRequest<TResponse>
        where TResponse : ResponseBase
    {
    }
}
