using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TRIMANA.Customer.Api.Controllers.Base
{
    [Route("api/Customer/[Controller]")]
    public class ControllerApiBase : ControllerBase
    {
        protected readonly IMediator _mediator;

        public ControllerApiBase(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
