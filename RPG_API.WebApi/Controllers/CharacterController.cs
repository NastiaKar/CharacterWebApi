using Microsoft.AspNetCore.Mvc;
using RPG_API.BLL.Services.Interfaces;
using RPG_API.Models.DTOs.Character;

namespace RPG_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CharacterController : ControllerBase
{
    private readonly ICharacterService _service;
    public CharacterController(ICharacterService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOne(int id)
    {
        return Ok(await _service.GetOne(id));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCharacterDTO character)
    {
        try
        {
            var displayCharacterDto = await _service.Create(character);
            return CreatedAtAction(nameof(GetOne), new {id = displayCharacterDto.Id}, displayCharacterDto);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromBody]UpdateCharacterDTO character, int id) {
        try
        {
            var displayCharacterDto = await _service.Update(character, id);
            return Ok(displayCharacterDto);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _service.Delete(id);
        }
        catch (Exception)
        {
            return NotFound();
        }

        return Ok();
    }
}