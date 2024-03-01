using Limakaz.Contracts;
using Limakaz.Database.DomainModels;
using Limakaz.ViewModels.Officies;
using System.ComponentModel.DataAnnotations;

namespace Limakaz.ViewModels.Auth
{
    public class RegisterViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password doesn't match. Please write again")]
        public string ConfirmPassword { get; set; }
        public string PhonePrefix { get; set; }
        public string PhoneNumber { get; set; }
        public string Nationality { get; set; }
        public DateTime BirthdayDate { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string FinCode { get; set; }
        public string SerialNumber { get; set; }
        public bool RulesAccepted { get; set; } = false;
        public int OfficeId { get; set; }
        public List<Database.DomainModels.Officies>? Officies { get; set; }
        public PersonType PersonType { get; set; }
        public NotificationType NotificationType { get; set; }
    }
}
