using ClassLib.Business;
using ClassLib.Data.Framework;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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

        // [WebAPI - 02]
        // TODO: Add HttpPost endpoint in UserController to insert a new User.
    }
}
