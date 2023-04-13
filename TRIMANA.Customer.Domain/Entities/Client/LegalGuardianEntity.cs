using TRIMANA.Customer.Domain.Enums;
using TRIMANA.Customer.Domain.Extensions;

namespace TRIMANA.Customer.Domain.Entities.Client;
public class LegalGuardianEntity
{

    public string Cpf { get; private set; }
    public string Phone { get; private set; }
    public string Email { get; private set; }
    public string LastName { get; private set; }
    public string FirstName { get; private set; }
    public GuardianType Type { get; private set; }
    public DateTime BirthdayDate { get; private set; }

    public LegalGuardianEntity(DateTime birthdayDate, GuardianType type, string firstName, string lastName)
    {
        Type = type;
        LastName = lastName;
        FirstName = firstName;
        BirthdayDate = birthdayDate;
    }

    public bool GuardiaoValidoParaCliente()
        => string.IsNullOrWhiteSpace(Email) && string.IsNullOrWhiteSpace(Cpf) && BirthdayDate.OverAge();
}
