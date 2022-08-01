using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerOfHabit.Application.DTOs;
using PowerOfHabit.Application.Interfaces;

namespace PowerOfHabit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleDTO>>> Get()
        {
            var roles = await _roleService.GetAllAsync();
            if (roles == null)
            {
                return NotFound("Roles not found");
            }
            return Ok(roles);
        }
    }
}
