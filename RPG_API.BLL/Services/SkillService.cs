using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RPG_API.BLL.Services.Interfaces;
using RPG_API.DAL.Data;
using RPG_API.DAL.Entities;
using RPG_API.Models.DTOs.Skill;

namespace RPG_API.BLL.Services;

public class SkillService : ISkillService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public SkillService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<DisplaySkillDTO>> GetAll()
    {
        var skills = await _context.Skills.ToListAsync();
        return _mapper.Map<IEnumerable<DisplaySkillDTO>>(skills);
    }

    public async Task<DisplaySkillDTO> GetOne(int id)
    {
        var skill = await _context.Skills.FirstOrDefaultAsync(s => s.Id == id);
        if (skill == null)
            throw new Exception("Skill not found");

        return _mapper.Map<DisplaySkillDTO>(skill);
    }

    public async Task<DisplaySkillDTO> Create(CreateSkillDTO request)
    {
        var skill = _mapper.Map<Skill>(request);
        await _context.Skills.AddAsync(skill);

        await _context.SaveChangesAsync();
        return _mapper.Map<DisplaySkillDTO>(skill);
    }

    public async Task<DisplaySkillDTO> Update(UpdateSkillDTO request, int id)
    {
        var skill = await _context.Skills.FirstOrDefaultAsync(s => s.Id == id);
        if (skill == null)
            throw new Exception("Skill not found");

        _mapper.Map(request, skill);
        _context.Skills.Update(skill);
        await _context.SaveChangesAsync();
        return _mapper.Map<DisplaySkillDTO>(skill);
    }

    public async Task Delete(int id)
    {
        var skill = await _context.Skills.FirstOrDefaultAsync(s => s.Id == id);
        if (skill == null)
            throw new Exception("Skill not found");

        _context.Skills.Remove(skill);
        await _context.SaveChangesAsync();
    }
}