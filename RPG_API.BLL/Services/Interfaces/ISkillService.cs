using RPG_API.Models.DTOs.Skill;

namespace RPG_API.BLL.Services.Interfaces;

public interface ISkillService
{
    Task<IEnumerable<DisplaySkillDTO>> GetAll();
    Task<DisplaySkillDTO> GetOne(int id);
    Task<DisplaySkillDTO> Create(CreateSkillDTO request);
    Task<DisplaySkillDTO> Update(UpdateSkillDTO request, int id);
    Task Delete(int id);
}