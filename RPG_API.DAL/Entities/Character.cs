using RPG_API.Models.Enums;

namespace RPG_API.DAL.Entities;

public class Character
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public RpgClass RpgClass { get; set; }
    public Weapon Weapon { get; set; } = null!;
    public List<Skill> Skills { get; set; } = null!;
}