using Limakaz.Database.DomainModels;

namespace Limakaz.Services.Abstract
{
    public interface IRegisterService
    {
       string GenerateCustomerCode();
        bool DoesCodeExist(string code);
        //List<Notifications> CreatOrderNotifications(Order order);

    }
}
