using Limakaz.Database.Abstracts;

namespace Limakaz.Database.DomainModels;

public class Country : IEntity
{
    public string? Name { get; set; }
    public string? CountryPrefix { get; set; }
    public bool IsActive { get; set; }
    public List<Tariff> Tariffs { get; set; }
}
