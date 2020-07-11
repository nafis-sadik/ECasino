using Infrastructure;
using LogicLayer.Abstraction;
using LogicLayer.Repositories;
using Models;
using Models.DataModels.Entities;
using Models.Entities;
using System;
using System.Security.Cryptography.X509Certificates;
using static Models.ConstantLibrary;

namespace LogicLayer.Implementation
{
    public class UserServices : IUserServices
    {
        private RepositoryBase<User> _userRepository;
        private ICrashLoggingService crashLoggingService;
        private dynamic response;
        public UserServices()
        {
            _userRepository = new RepositoryBase<User>();
            crashLoggingService = new CrashLoggingService();
            response = new ResponseModel<User>();
        }

        public ResponseModel<User> CheckUserInDatabase(ulong playerId)
        {
            try 
            {
                var player = _userRepository.Get(x => x.PlayerID == playerId);
                if (player != null) { response.ObjResponse = player; }
                response.IsValidResponse = true;
            }
            catch (Exception ex)
            {
                response.IsValidResponse = false;
                response.msg = "Error: Excepton at UserServices => CheckUserInDatabase => " + ex.Message;
                crashLoggingService.log(response.msg);
            }
            return response;
        }

        public ResponseModel<User> RegisterUser(User user)
        {
            try 
            {
                if (user.PlayerID > 0) {
                    _userRepository.Add(user);
                    response.ObjResponse = user;
                    response.msg = ResponseConstant.Success;
                }
                response.IsValidResponse = true;
                _userRepository.Save();
                _userRepository.Commit();
            }
            catch (Exception ex)
            {
                _userRepository.Rollback();
                response.IsValidResponse = false;
                response.msg = "Error: Excepton at UserServices => RegisterUser => " + ex.InnerException.Message;
                crashLoggingService.log(response.msg);
            }
            return response;
        }
    }
}
