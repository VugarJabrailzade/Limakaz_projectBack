using Limakaz.Database;
using Limakaz.Database.DomainModels;

namespace Limakaz.Services.Concretes
{
    public class RegisterService
    {
        public LimakDbContext _limakDbContext;

        public RegisterService(LimakDbContext limakDbContext)
        {
            _limakDbContext = limakDbContext;
        }

        
    }
}
