using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RPG_API.BLL.Services.Interfaces;
using RPG_API.DAL.Data;
using RPG_API.DAL.Entities;
using RPG_API.Models.DTOs.Weapon;
namespace RPG_API.BLL.Services;

public class WeaponService : IWeaponService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public WeaponService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<DisplayWeaponDTO>> GetAll()
    {
        var weapons = await _context.Weapons.ToListAsync();
        return _mapper.Map<IEnumerable<DisplayWeaponDTO>>(weapons);
    }

    public async Task<DisplayWeaponDTO> GetOne(int id)
    {
        var weapon = await _context.Weapons.FirstOrDefaultAsync(w => w.Id == id);
        if (weapon == null)
            throw new Exception("Weapon not found");

        return _mapper.Map<DisplayWeaponDTO>(weapon);
    }

    public async Task<DisplayWeaponDTO> Create(CreateWeaponDTO request)
    {
        var weapon = _mapper.Map<Weapon>(request);
        await _context.Weapons.AddAsync(weapon);

        await _context.SaveChangesAsync();
        return _mapper.Map<DisplayWeaponDTO>(weapon);
    }

    public async Task<DisplayWeaponDTO> Update(UpdateWeaponDTO request, int id)
    {
        var weapon = await _context.Weapons.FirstOrDefaultAsync(w => w.Id == id);
        if (weapon == null)
            throw new Exception("Weapon not found");

        _mapper.Map(request, weapon);
        _context.Weapons.Update(weapon);
        await _context.SaveChangesAsync();
        return _mapper.Map<DisplayWeaponDTO>(weapon);
    }

    public async Task Delete(int id)
    {
        var weapon = await _context.Weapons.FirstOrDefaultAsync(w => w.Id == id);
        if (weapon == null)
            throw new Exception("Weapon not found");

        _context.Weapons.Remove(weapon);
        await _context.SaveChangesAsync();
    }
}