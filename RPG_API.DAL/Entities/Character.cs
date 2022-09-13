using System.ComponentModel.DataAnnotations.Schema;
using RPG_API.Models.Enums;

namespace RPG_API.DAL.Entities;

public class Character
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public RpgClass RpgClass { get; set; }
    [ForeignKey(nameof(WeaponId))]
    public Weapon? Weapon { get; set; } = null!;
    public int? WeaponId { get; set; }
    public List<Skill> Skills { get; set; } = null!;
}