using FluentValidation.Results;
using TRIMANA.Customer.Application.Base;
using TRIMANA.Customer.Domain.Messages.Requests;
using TRIMANA.Customer.Domain.Messages.Responses;

namespace TRIMANA.Customer.Application.Handlers
{
    public class SignUpClientHandler : RequestHandlerBase<SignUpClientRequest, SignUpClientResponse>
    {
        public SignUpClientHandler() 
        {
        }

        public override Task<SignUpClientResponse> Handle(SignUpClientRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
