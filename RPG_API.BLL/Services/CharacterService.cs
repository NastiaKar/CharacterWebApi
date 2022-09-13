using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RPG_API.BLL.Services.Interfaces;
using RPG_API.DAL.Data;
using RPG_API.DAL.Entities;
using RPG_API.Models.DTOs.Character;

namespace RPG_API.BLL.Services;

public class CharacterService : ICharacterService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;


    public CharacterService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<DisplayCharacterDTO>> GetAll()
    {
        var characters = await _context.Characters
            .Include(c => c.Weapon)
            .Include(c => c.Skills)
            .ToListAsync();
        return _mapper.Map<IEnumerable<DisplayCharacterDTO>>(characters);
    }

    public async Task<DisplayCharacterDTO> GetOne(int id)
    {
        var character = await _context.Characters
            .Include(c => c.Weapon)
            .Include(c => c.Skills)
            .FirstOrDefaultAsync(c => c.Id == id);
        if (character == null)
            throw new Exception("Character not found");

        return _mapper.Map<DisplayCharacterDTO>(character);
    }

    public async Task<DisplayCharacterDTO> Create(CreateCharacterDTO request)
    {
        var weapon = await _context.Weapons.FirstOrDefaultAsync(w => request.WeaponId == w.Id);
        if (weapon == null)
            throw new Exception("Weapon not found");
        var skills = new List<Skill>();
        foreach (int id in request.SkillIds.Distinct())
        {
            var skill = await _context.Skills.FirstOrDefaultAsync(s => s.Id == id);
            if (skill == null)
                throw new Exception("Skill not found");
            skills.Add(skill);
        }

        var character = _mapper.Map<Character>(request);
        character.Skills = skills;
        await _context.Characters.AddAsync(character);

        await _context.SaveChangesAsync();
        return _mapper.Map<DisplayCharacterDTO>(character);
    }

    public async Task<DisplayCharacterDTO> Update(UpdateCharacterDTO request, int id)
    {
        var weapon = await _context.Weapons.FirstOrDefaultAsync(w => request.WeaponId == w.Id);
        if (weapon == null)
            throw new Exception("Weapon not found");

        var skills = new List<Skill>();
        
        foreach (int skillId in request.SkillIds)
        {
            var skill = await _context.Skills.FirstOrDefaultAsync(s => s.Id == skillId);
            if (skill == null)
                throw new Exception("Skill not found");
            
            skills.Add(skill);
        }
        
        var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);
        if (character == null)
            throw new Exception("Character not found");

        _mapper.Map(request, character);
        _context.Characters.Update(character);
        await _context.SaveChangesAsync();
        return _mapper.Map<DisplayCharacterDTO>(character);
    }

    public async Task Delete(int id)
    {
        var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);
        if (character == null)
            throw new Exception("Character not found");

        _context.Characters.Remove(character);
        await _context.SaveChangesAsync();
    }
}