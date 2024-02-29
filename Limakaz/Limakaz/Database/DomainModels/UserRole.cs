using Limakaz.Contracts;
using Limakaz.Database.Abstracts;

namespace Limakaz.Database.DomainModels
{
    public class UserRole : IEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
