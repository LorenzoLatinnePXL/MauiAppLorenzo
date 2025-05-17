using ClassLib.Business;
using ClassLib.Data.Framework;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApp.DTO;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        // Sprint 3 – Web API + Class Library:
        private ActionResult HandleResult(SelectResult result)
        {
            return result.Succeeded ? Ok(JsonConvert.SerializeObject(result.DataTable, Formatting.Indented)) : BadRequest(result.Errors);
        }

        [HttpGet]
        public ActionResult GetUsers() => HandleResult(Users.GetUsers());

        [HttpPost]
        private ActionResult CreateUser(CreateAccountRequest request)
        {
            if (Users.CheckIfUsernameIsTaken(request.Username))
                return BadRequest("Username is already taken.");

            if (Users.CheckIfEmailIsTaken(request.Email))
                return BadRequest("Email is already in use.");

            if (!Users.CheckEmailFormat(request.Email))
                return BadRequest("Invalid email format.");

            Users.Add(request.Username, request.Password, request.Email);

            return Ok("User has been created successfully.");
        }
    }
}
