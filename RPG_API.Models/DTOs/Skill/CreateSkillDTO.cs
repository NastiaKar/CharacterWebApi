namespace RPG_API.Models.DTOs.Skill;

public class CreateSkillDTO
{
    public string Name { get; set; } = String.Empty;
    public int Damage { get; set; }
}