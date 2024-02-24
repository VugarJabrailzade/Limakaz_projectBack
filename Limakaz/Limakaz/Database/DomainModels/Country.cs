using Limakaz.Database.Abstracts;

namespace Limakaz.Database.DomainModelsı
{
    public class Country : IEntity
    {
        public string Name { get; set; }
        public string CountryPrefix { get; set; }
        public bool IsActive { get; set; }
    }
}
