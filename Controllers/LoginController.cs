using Doors_API.DTO;
using Doors_API.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Doors_API.Controllers
{
    public class LoginController : ApiController
    {

        [HttpPost]
        public IHttpActionResult Authenticate([FromBody] LoginUser user)
        {
            IHttpActionResult response;

            UserService userService = new UserService();

            var token = userService.Login(user.username, user.password);

            if (token == null || token == String.Empty)
            {
                HttpResponseMessage loginResponse = new HttpResponseMessage();
                loginResponse.StatusCode = HttpStatusCode.Unauthorized;
                loginResponse.Content = new StringContent("User name or password is incorrect");
                response = ResponseMessage(loginResponse);
                return response;
            }

            return Ok<string>(token);
        }

      
    }
}
