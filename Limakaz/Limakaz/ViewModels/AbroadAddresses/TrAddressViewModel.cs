using System.ComponentModel.DataAnnotations;

namespace Limakaz.ViewModels.AbroadAddresses
{
    public class TrAddressViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ölkəni əlavə edin.")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Şəhəri əlavə edin.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Regionu əlavə edin.")]
        public string Region { get; set; }

        [Required(ErrorMessage = "Adresi əlavə edin.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "İş günlərini qeyd edin.")]
        public string WorkingDays { get; set; }

        [Required(ErrorMessage = "İş saatlarını qeyd edin.")]
        public string WorkingHours { get; set; }

        [Required(ErrorMessage = "Poct kodunu əlavə edin.")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Pasport kodunu əlavə edin.")]
        public string PassportCode { get; set; }

        public string TaxNumber { get; set; }

        public string PhoneNumber { get; set; }
    }
}
