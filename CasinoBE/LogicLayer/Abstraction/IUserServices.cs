using Models.DataModels.Entities;
using Models.Entities;

namespace LogicLayer.Abstraction
{
    public interface IUserServices
    {
        ResponseModel<User> CheckUserInDatabase(ulong user);
        ResponseModel<User> RegisterUser(User user);
    }
}
