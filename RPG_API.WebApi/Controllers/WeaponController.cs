using Microsoft.AspNetCore.Mvc;
using RPG_API.BLL.Services.Interfaces;
using RPG_API.Models.DTOs.Weapon;

namespace RPG_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WeaponController : ControllerBase
{
    private readonly IWeaponService _service;
    public WeaponController(IWeaponService service)
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
    public async Task<IActionResult> Create([FromBody]CreateWeaponDTO weapon)
    {
        try
        {
            var displayWeaponDto = await _service.Create(weapon);
            return CreatedAtAction(nameof(GetOne), new {id = displayWeaponDto.Id}, displayWeaponDto);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromBody]UpdateWeaponDTO weapon, int id)
    {
        try
        {
            var displayWeaponDto = await _service.Update(weapon, id);
            return Ok(displayWeaponDto);
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