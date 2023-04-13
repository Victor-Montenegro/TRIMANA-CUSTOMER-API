using TRIMANA.Customer.Domain.Entities.Base;

namespace TRIMANA.Customer.Domain.Entities.Client;

public class ClientEntity : EntityBase
{

    public string Email { get; private set; }
    public string Phone { get; private set; }
    public string LastName { get; private set; }
    public string Password { get; private set; }
    public string FirstName { get; private set; }
    public DateTime BirthdayDate { get; private set; }
    public bool HasLegaGuardian { get; private set; }

    //public ClientEntity(string email, string phone, string lastName, string password, string firstName, DateTime birthdayDate)
    //{
    //    Email = email;
    //    Phone = phone;
    //    LastName = lastName;
    //    Password = password;
    //    FirstName = firstName;
    //    BirthdayDate = birthdayDate;
    //}
}