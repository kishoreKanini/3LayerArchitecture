using Microsoft.AspNetCore.Mvc;
using Kanini.EvaluationPortalFile.DataAccessLayer.Interface;
using Kanini.EvaluationPortalFile.DataAccessLayer.Entity;
using Microsoft.AspNetCore.Authorization;

namespace Kanini.EvaluationPortal.UI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
       private readonly IUserRepository userRepository;
        public UserController(IUserRepository _userRepository)
        {
            this.userRepository = _userRepository;
        }

        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers(){
            var res = this.userRepository.GetAllUsers();
            return Ok(res);
        }

        [HttpPost("AddUser")]
        public IActionResult AddUser(User user){
            var res = this.userRepository.AddUser(user);
            return Ok(res);
        }

        [HttpPost("UpdateUser")]
        public IActionResult UpdateUser(User user){
            var res = this.userRepository.UpdateUser(user);
            return Ok(res);
        }

        [HttpDelete("DeleteUser")]
        public IActionResult DeleteUser(User user){
            var res = this.userRepository.DeleteUser(user);
            return Ok(res);
        }
    }
}