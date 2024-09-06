using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Transactions;
using UserService.Models;
using UserService.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get()
        {
            var users = _userRepository.GetUsers();
            return new OkObjectResult(users);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _userRepository.GetUserById(id);
            return new OkObjectResult(user);
        }

        // POST <UserController>
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            using (var scope = new TransactionScope())
            {
                _userRepository.AddUser(user);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = user.Id });
            }
        }

        
        [HttpPut]
        public IActionResult Put([FromBody] User user)
        {
            if (user != null)
            {
                using (var scope = new TransactionScope())
                {
                    _userRepository.UpdateUser(user);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpGet("[action]/{sessionId}")]
        public IActionResult ValidateUser(string sessionId)
        {
            var isUserExists = _userRepository.ValidateUser(sessionId);
            if (isUserExists)
                return new OkResult();
            else
                return new UnauthorizedResult();
        }


        [HttpGet("login/{email}/{password}")]
        public IActionResult Login(string email, string password)
        {
            var sessionId = _userRepository.GetUserLogin(email, password);
            if (sessionId != "")
                return new OkObjectResult(new { id = sessionId });
            else
                return new UnauthorizedResult();
        }

        [HttpGet("logout/{sessionId}")]
        public IActionResult Logout(string sessionId)
        {
            var isSuccess = _userRepository.Logout(sessionId);
            if (isSuccess)
                return new OkResult();
            else
                return new UnauthorizedResult();
        }
    }
}
