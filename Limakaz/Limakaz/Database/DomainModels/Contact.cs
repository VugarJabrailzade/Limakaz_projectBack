using Limakaz.Database.Abstracts;

namespace Limakaz.Database.DomainModels
{
    public class Contact : IEntity
    {
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
