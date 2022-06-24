using EAuction.APIGateway.Models;
using EAuction.APIGateway.Repositories.Abstractions;
using EAuction.APIGateway.Services;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace APIGateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        #region Variables

        private IUserRepository _userRepository;

        #endregion
        #region Constructor
        public AuthController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        #endregion

        [HttpPost("validateuser/{email}/{password}")]
        [AllowAnonymous]
        public async Task<ActionResult<User>> ValidateUser(string email, string password)
        {
            var _user = await _userRepository.GetUser(email, password);

            if (_user != null)
            {
                _user.Token = new AuctionTokenService().GenerateToken(_user).Token;
            }
            else
            {
                throw new System.Exception("User name or password is invalid");
            }

            return Ok(_user);
        }

        [HttpPost]
        [Route("createuser")]
        [AllowAnonymous]
        public async Task CreateUser([FromBody] User user)
        {
            await _userRepository.Create(user);
        }
    }
}
