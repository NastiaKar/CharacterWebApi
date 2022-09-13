using RPG_API.Models.DTOs.Character;
using RPG_API.Models.DTOs.Skill;

namespace RPG_API.BLL.Services.Interfaces;

public interface ICharacterService
{
    Task<IEnumerable<DisplayCharacterDTO>> GetAll();
    Task<DisplayCharacterDTO> GetOne(int id);
    Task<DisplayCharacterDTO> Create(CreateCharacterDTO request);
    Task<DisplayCharacterDTO> Update(UpdateCharacterDTO request, int id);
    Task Delete(int id);
}