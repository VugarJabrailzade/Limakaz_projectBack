using Limakaz.Database.Abstracts;
using System.ComponentModel.DataAnnotations;

namespace Limakaz.Database.DomainModels
{
    public class AbroadAddressUs : IEntity
    {
        [Required(ErrorMessage = "Add country name.")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Add city name.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Add state name.")]
        public string State { get; set; }

        [Required(ErrorMessage = "Add addressLine.")]
        public string AddressLine { get; set; }

        [Required(ErrorMessage = "Add working days.")]
        public string WorkingDays { get; set; }

        [Required(ErrorMessage = "Add working hours.")]
        public string WorkingHours { get; set; }

        [Required(ErrorMessage = "Add Zip/Postal code.")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Add phone number.")]
        public string PhoneNumber { get; set; }
    }
}
