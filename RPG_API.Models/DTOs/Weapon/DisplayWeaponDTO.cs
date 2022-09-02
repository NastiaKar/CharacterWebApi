namespace RPG_API.Models.DTOs.Weapon;

public class DisplayWeaponDTO
{
    public int Id { get; set; }
    public int CharacterId { get; set; }
    public string Name { get; set; } = String.Empty;
    public int Damage { get; set; }
}