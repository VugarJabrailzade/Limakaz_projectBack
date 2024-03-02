using Limakaz.Database;
using Limakaz.Database.DomainModels;
using Limakaz.Services.Abstract;

namespace Limakaz.Services.Concretes
{
    public class RegisterService : IRegisterService
    {
        public LimakDbContext _limakDbContext;

        public RegisterService(LimakDbContext limakDbContext)
        {
            _limakDbContext = limakDbContext;
        }

        public string GenerateCustomerCode()
        {
            var random = new Random();
            string code;
            string numberPart;


            do
            {
                numberPart = random.Next(1, 100000).ToString();
                code = $"00{numberPart.PadLeft(5, '0')}";
            } while (DoesCodeExist(code));

            return code;
        }

        public bool DoesCodeExist(string code)
        {
            return false;
        }
    }
}
