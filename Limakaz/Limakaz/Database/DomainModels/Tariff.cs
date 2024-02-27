using Limakaz.Database.Abstracts;
using Limakaz.Database.DomainModelsı;

namespace Limakaz.Database.DomainModels
{
    public class Tariff : IEntity
    {
        public string Weight { get; set; }
        public decimal PriceAzn {  get; set; }
        public decimal PriceUsd { get; set; }
        public int? CountryId { get; set; }
        public Country Country { get; set; }
    }
}
