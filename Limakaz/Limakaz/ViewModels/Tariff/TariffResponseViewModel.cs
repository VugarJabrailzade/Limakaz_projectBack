using Limakaz.Database.DomainModels;

namespace Limakaz.ViewModels.Tariff
{
    public class TariffResponseViewModel : TariffViewModel
    {
        public List<Country> Country { get; set; }
    }
}
