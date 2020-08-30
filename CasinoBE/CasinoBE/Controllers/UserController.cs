using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogicLayer.Abstraction;
using LogicLayer.Implementation;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Models.DataModels;
using Models.DataModels.Entities;
using Microsoft.AspNetCore.Http;
namespace CasinoBE.Controllers
{
    public class UserController : Controller
    {
        IUserServices userServices;
        ResponseModel<Player> response;

        public UserController()
        {
            userServices = new UserServices();
            response = new ResponseModel<Player>();
        }

        [HttpGet]
        public IActionResult CheckRegistration(ulong id)
        {
            response = userServices.CheckUserInDatabase(id);
            if (response.IsValidResponse)
                if (response.ObjResponse != null)
                    return StatusCode(StatusCodes.Status200OK);
                else
                    return StatusCode(StatusCodes.Status204NoContent);
            else
                return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPost]
        public IActionResult RegisterNewUser(Player user)
        {
            response = userServices.RegisterUser(user);
            if (response.IsValidResponse)
                return StatusCode(StatusCodes.Status201Created);
            else
                return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
