using FluentValidation.Results;
using MediatR;
using TRIMANA.Customer.Domain.Messages.Requests.Base;
using TRIMANA.Customer.Domain.Messages.Responses.Base;

namespace TRIMANA.Customer.Application.Base
{
    public abstract class RequestHandlerBase<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TResponse : ResponseBase
        where TRequest : RequestBase<TResponse>
    {
        private readonly ValidationResult _validationResult;

        public RequestHandlerBase()
        {
            _validationResult = new();
        }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);

        public ValidationResult HasError(string propertyName, string errorMessage)
        {
            _validationResult.Errors.Add(new ValidationFailure(propertyName, errorMessage));
            return _validationResult;
        }

        public ValidationResult HasError(string errorMessage)
            => HasError(string.Empty, errorMessage);
    }
}
