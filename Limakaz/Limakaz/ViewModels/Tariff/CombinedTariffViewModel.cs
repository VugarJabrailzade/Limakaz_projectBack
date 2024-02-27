using Limakaz.Database.DomainModels;

namespace Limakaz.ViewModels.Tariff
{
    public class CombinedTariffViewModel
    {
        public List<Database.DomainModels.Tariff> Tariffs { get; set; }
        public List<Database.DomainModels.Officies> Officies { get; set; }
    }
}
