using RPG_API.Models.DTOs.Weapon;

namespace RPG_API.BLL.Services.Interfaces;

public interface IWeaponService
{
    Task<IEnumerable<DisplayWeaponDTO>> GetAll();
    Task<DisplayWeaponDTO> GetOne(int id);
    Task<DisplayWeaponDTO> Create(CreateWeaponDTO request);
    Task<DisplayWeaponDTO> Update(UpdateWeaponDTO request, int id);
    Task Delete(int id);
}