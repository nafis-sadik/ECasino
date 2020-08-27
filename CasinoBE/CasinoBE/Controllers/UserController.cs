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
        [EnableCors("Allow CORS for Facebook & DevEnv")]
        public IActionResult CheckRegistration(ulong id)
        {
            response = userServices.CheckUserInDatabase(id);
            if (response.IsValidResponse)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpPost]
        public IActionResult RegisterNewUser(Player user)
        {
            response = userServices.RegisterUser(user);
            if (response.IsValidResponse)
                return Ok();
            else
                return BadRequest(response.msg);
        }
    }
}
