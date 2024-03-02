

using Limakaz.Contracts;
using System.ComponentModel.DataAnnotations;

namespace Limakaz.ViewModels.Auth
{
    public class RegisterResponseViewModel 
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Adı daxil edin.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyadı daxil edin.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Emaili daxil edin.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Parolu daxil edin.")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Parol eyni deyil")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Mobil nömrə prefixini seçin.")]
        public string PhonePrefix { get; set; }

        [Required(ErrorMessage = "Mobil nömrəni daxil edin.")]
        public string PhoneNumber { get; set; }

        public string Nationality { get; set; }

        [Required(ErrorMessage = "Doğum tarixini daxil edin.")]
        public DateTime BirthdayDate { get; set; }

        public string Gender { get; set; }
        public string Address { get; set; }

        [Required(ErrorMessage = "Finkodu düzgün daxil edin.")]
        public string FinCode { get; set; }

        [Required(ErrorMessage = "Ş/V seria nömrəsini daxil edin.")]
        public string SerialNumber { get; set; }
        public bool RulesAccepted { get; set; }
        public int OfficeId { get; set; }
        public List<Database.DomainModels.Officies>? Officies { get; set; }
        public PersonType PersonType { get; set; }
        public NotificationType NotificationType { get; set; }
    }
}
