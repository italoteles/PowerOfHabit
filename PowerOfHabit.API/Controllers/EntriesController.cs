using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerOfHabit.Application.DTOs;
using PowerOfHabit.Application.Interfaces;

namespace PowerOfHabit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntriesController : ControllerBase
    {
        private readonly IEntryService _entryService;
        public EntriesController(IEntryService entryService)
        {
            _entryService = entryService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntryDTO>>> Get()
        {
            var entries = await _entryService.GetAllAsync();
            if (entries == null)
            {
                return NotFound("Entries not found");
            }
            return Ok(entries);
        }

        [HttpGet("{id:int}", Name = "GetEntryById")]
        public async Task<ActionResult<EntryDTO>> Get(int id)
        {
            var entry = await _entryService.GetByIdAsync(id);
            if (entry == null)
            {
                return NotFound("Entry not found");
            }
            return Ok(entry);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EntryDTO entryDTO)
        {
            if (entryDTO == null)
            {
                return BadRequest("Invalid Data");
            }
            await _entryService.CreateAsync(entryDTO);

            return new CreatedAtRouteResult("GetEntryById", new { id = entryDTO.EntryId }, entryDTO);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] EntryDTO entryDTO)
        {
            if (id != entryDTO.EntryId)
            {
                return BadRequest("Invalid Id");
            }
            if (entryDTO == null)
            {
                return BadRequest("Invalid Data");
            }
            await _entryService.UpdateAsync(entryDTO);

            return Ok(entryDTO);

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<EntryDTO>> Delete(int id)
        {
            var entry = await _entryService.GetByIdAsync(id);
            if (entry == null)
            {
                return NotFound("Entry not found");
            }
            await _entryService.DeleteAsync(id);
            return Ok(entry);
        }
    }
}
