using Limakaz.Database.Abstracts;

namespace Limakaz.Database.DomainModels
{
    public class AbroadAddressTr : IEntity
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Address {  get; set; }
        public string WorkingDays { get; set; }
        public string WorkingHours { get; set; }
        public string PostalCode { get; set; }
        public string PassportCode { get; set; }
        public string TaxNumber { get; set; }
        public string PhoneNumber { get; set; }


    }
}
