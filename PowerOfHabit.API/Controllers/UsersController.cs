using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerOfHabit.Application.DTOs;
using PowerOfHabit.Application.Interfaces;

namespace PowerOfHabit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> Get()
        {
            var users = await _userService.GetAllAsync();
            if (users == null)
            {
                return NotFound("Users not found");
            }
            return Ok(users);
        }

        [HttpGet("{id:int}", Name = "GetUserById")]
        public async Task<ActionResult<UserDTO>> Get(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound("User not found");
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserDTO userDTO)
        {
            if (userDTO == null)
            {
                return BadRequest("Invalid Data");
            }
            await _userService.CreateAsync(userDTO);

            return new CreatedAtRouteResult("GetUserById", new { id = userDTO.UserId }, userDTO);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] UserDTO userDTO)
        {
            if (id != userDTO.UserId)
            {
                return BadRequest("Invalid Id");
            }
            if (userDTO == null)
            {
                return BadRequest("Invalid Data");
            }
            await _userService.UpdateAsync(userDTO);

            return Ok(userDTO);

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<UserDTO>> Delete(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound("User not found");
            }
            await _userService.DeleteAsync(id);
            return Ok(user);
        }

    }
}
