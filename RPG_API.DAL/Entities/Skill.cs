namespace RPG_API.DAL.Entities;

public class Skill
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public int Damage { get; set; }
    public List<Character> Characters { get; set; } = null!;
}