using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PowerOfHabit.Application.DTOs;
using PowerOfHabit.Application.Interfaces;

namespace PowerOfHabit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupService _groupService;
        public GroupsController(IGroupService groupService)
        {
            _groupService = groupService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupDTO>>> Get()
        {
            var groups = await _groupService.GetAllAsync();
            if (groups == null)
            {
                return NotFound("Groups not found");
            }
            return Ok(groups);
        }

        [HttpGet("{id:int}", Name = "GetGroupById")]
        public async Task<ActionResult<GroupDTO>> Get(int id)
        {
            var group = await _groupService.GetByIdAsync(id);
            if (group == null)
            {
                return NotFound("Group not found");
            }
            return Ok(group);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GroupDTO groupDTO)
        {
            if (groupDTO == null)
            {
                return BadRequest("Invalid Data");
            }
            await _groupService.CreateAsync(groupDTO);

            return new CreatedAtRouteResult("GetGroupById", new { id = groupDTO.GroupId }, groupDTO);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] GroupDTO groupDTO)
        {
            if (id != groupDTO.GroupId)
            {
                return BadRequest("Invalid Id");
            }
            if (groupDTO == null)
            {
                return BadRequest("Invalid Data");
            }
            await _groupService.UpdateAsync(groupDTO);

            return Ok(groupDTO);

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<GroupDTO>> Delete(int id)
        {
            var group = await _groupService.GetByIdAsync(id);
            if (group == null)
            {
                return NotFound("Group not found");
            }
            await _groupService.DeleteAsync(id);
            return Ok(group);
        }
    }
}
