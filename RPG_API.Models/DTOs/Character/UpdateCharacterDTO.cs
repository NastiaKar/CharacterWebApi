namespace RPG_API.Models.DTOs.Character;

public class UpdateCharacterDTO
{
    public string Name { get; set; } = String.Empty;
    public int? WeaponId { get; set; }
    public List<int> SkillIds { get; set; } = new();
}