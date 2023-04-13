using TRIMANA.Customer.Application.Base;
using TRIMANA.Customer.Domain.Messages.Requests;
using TRIMANA.Customer.Domain.Messages.Responses;
using TRIMANA.Customer.Infrastructure.Repositories.Client;

namespace TRIMANA.Customer.Application.Handlers
{
    public class SignUpClientHandler : RequestHandlerBase<SignUpClientRequest, SignUpClientResponse>
    {
        private readonly IClientRepository _clientRepository;

        public SignUpClientHandler(IClientRepository clientRepository) 
        {
            _clientRepository = clientRepository;
        }

        public override async Task<SignUpClientResponse> Handle(SignUpClientRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _clientRepository.GetById(1);
            }
            catch (Exception)
            {

                throw new Exception("Testando");
            }
            return new SignUpClientResponse();
        }
    }
}
