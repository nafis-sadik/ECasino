using Models.DataModels;
using Models.DataModels.Entities;
using Models.Entities;

namespace LogicLayer.Abstraction
{
    public interface IUserServices
    {
        ResponseModel<Player> CheckUserInDatabase(ulong user);
        ResponseModel<Player> RegisterUser(Player user);
    }
}
