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

        [HttpGet("{id:int}", Name = "GetRoleById")]
        public async Task<ActionResult<RoleDTO>> Get(int id)
        {
            var role = await _roleService.GetByIdAsync(id);
            if (role == null)
            {
                return NotFound("Role not found");
            }
            return Ok(role);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RoleDTO roleDTO)
        {
            if (roleDTO == null)
            {
                return BadRequest("Invalid Data");
            }
            await _roleService.CreateAsync(roleDTO);

            return new CreatedAtRouteResult("GetRoleById", new { id = roleDTO.RoleId }, roleDTO);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] RoleDTO roleDTO)
        {
            if (id != roleDTO.RoleId)
            {
                return BadRequest("Invalid Id");
            }
            if (roleDTO == null)
            {
                return BadRequest("Invalid Data");
            }
            await _roleService.UpdateAsync(roleDTO);

            return Ok(roleDTO);

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<RoleDTO>> Delete(int id)
        {
            var role = await _roleService.GetByIdAsync(id);
            if(role == null)
            {
                return NotFound("Role not found");
            }
            await _roleService.DeleteAsync(id);
            return Ok(role);
        }
    }
}
