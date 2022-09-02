using Microsoft.AspNetCore.Mvc;
using RPG_API.BLL.Services.Interfaces;
using RPG_API.Models.DTOs.Skill;

namespace RPG_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SkillController : ControllerBase
{
    private readonly ISkillService _service;
    public SkillController(ISkillService service)
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
    public async Task<IActionResult> Create([FromBody]CreateSkillDTO skill)
    {
        try
        {
            var displaySkillDto = await _service.Create(skill);
            return CreatedAtAction(nameof(GetOne), new {id = displaySkillDto.Id}, displaySkillDto);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromBody]UpdateSkillDTO skill, int id)
    {
        try
        {
            var displaySkillDto = await _service.Update(skill, id);
            return Ok(displaySkillDto);
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