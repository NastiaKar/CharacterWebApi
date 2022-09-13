using System.ComponentModel.DataAnnotations.Schema;

namespace RPG_API.DAL.Entities;

public class Weapon
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public int Damage { get; set; }
    [ForeignKey(nameof(CharacterId))]
    public Character? Character { get; set; } = null!;
    public int? CharacterId { get; set; }
}