using Limakaz.Contracts;
using Limakaz.Database.Abstracts;

namespace Limakaz.Database.DomainModels;

public class User : IEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string CustomerCode { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public bool IsEmailConfirmed { get; set; }
    public string Nationality { get; set; }
    public bool PhoneNumberConfirmed { get; set; }
    public DateTime BirthdayDate { get; set; }
    public string Gender { get; set; }
    public bool IsAdmin  { get; set; }
    public string Address { get; set; }
    public string FinCode { get; set; }
    public string SerialNumber { get; set; }
    public bool RulesAccepted {  get; set; } 
    public int OfficeId { get; set; }
    public List<Officies> Officies { get; set; }
    public PersonType PersonType { get; set; }
    public NotificationType NotificationType { get; set; }
    public List<UserRole>? UserRole { get; set; }



}
