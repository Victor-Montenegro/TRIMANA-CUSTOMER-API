using MediatR;
using Microsoft.AspNetCore.Mvc;
using TRIMANA.Customer.Api.Controllers.Base;
using TRIMANA.Customer.Domain.Messages.Requests;
using TRIMANA.Customer.Domain.Messages.Responses;

namespace TRIMANA.Customer.Api.Controllers.Client
{
    public class ClientController : ControllerApiBase
    {
        public ClientController(IMediator mediator) : base(mediator){}

        [HttpPost]
        [Route("SignUpClient")]
        [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(SignUpClientResponse))]
        public async Task<IActionResult> SignUpClient([FromBody] SignUpClientRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(request);
        }
    }
}
