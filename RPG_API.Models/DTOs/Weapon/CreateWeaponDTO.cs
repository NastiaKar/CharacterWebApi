namespace RPG_API.Models.DTOs.Weapon;

public class CreateWeaponDTO
{
    public int CharacterId { get; set; }
    public string Name { get; set; } = String.Empty;
    public int Damage { get; set; }
}