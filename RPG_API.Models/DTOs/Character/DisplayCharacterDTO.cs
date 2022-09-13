using RPG_API.Models.DTOs.Skill;
using RPG_API.Models.DTOs.Weapon;

namespace RPG_API.Models.DTOs.Character;

public class DisplayCharacterDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string RpgClass { get; set; } = String.Empty;
    public DisplayWeaponDTO? Weapon { get; set; } = null!;
    public int? WeaponId { get; set; }
    public List<DisplaySkillDTO> Skills { get; set; } = new();
}