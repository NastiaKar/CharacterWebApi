namespace RPG_API.DAL.Entities;

public class Weapon
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public int Damage { get; set; }
    public Character Character { get; set; } = null!;
    public int CharacterId { get; set; }
}