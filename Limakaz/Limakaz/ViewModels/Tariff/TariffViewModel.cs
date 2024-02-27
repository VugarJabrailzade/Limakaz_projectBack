using Limakaz.Database.DomainModels;

namespace Limakaz.ViewModels.Tariff;

public class TariffViewModel
{

    public int Id { get; set; }
    public string Weight { get; set; }
    public decimal PriceAzn { get; set; }
    public decimal PriceUsd { get; set; }
    public int? CountryId { get; set; }

}
