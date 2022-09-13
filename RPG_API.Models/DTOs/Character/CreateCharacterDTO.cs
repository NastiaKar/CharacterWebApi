using RPG_API.Models.DTOs.Skill;
using RPG_API.Models.DTOs.Weapon;
using RPG_API.Models.Enums;

namespace RPG_API.Models.DTOs.Character;

public class CreateCharacterDTO
{
    public string Name { get; set; } = String.Empty;
    public string RpgClass { get; set; } = String.Empty;
    public int? WeaponId { get; set; }
    public List<int> SkillIds { get; set; } = new();
}