using TRIMANA.Customer.Domain.Messages.Requests.Base;
using TRIMANA.Customer.Domain.Messages.Responses;

namespace TRIMANA.Customer.Domain.Messages.Requests;

public class SignUpClientRequest : RequestBase<SignUpClientResponse>
{
    public string Email { get; set; }
    public string Phone { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
}
