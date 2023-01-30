using Microsoft.AspNetCore.Mvc;
using WebApplicationAPI.Models.DTO;
using WebApplicationAPI.Repositories;

namespace WebApplicationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
   // [Route("[]")]
    public class AuthController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly ITokenHandler token;
        public AuthController(IUserRepository userRepo,ITokenHandler tokenHandler)
        {
            this.userRepository = userRepo;
            this.token = tokenHandler;
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
           var user = await userRepository.AuthenticateUser(loginRequest.Username, loginRequest.Password);
            if(user != null)
            {
                //genrate token
                var authToken = token.CreateTokenAsync(user);
                return Ok(authToken);
            }
            else
            {
                return BadRequest("Username & password is not correct");
            }
        }
    }
}
