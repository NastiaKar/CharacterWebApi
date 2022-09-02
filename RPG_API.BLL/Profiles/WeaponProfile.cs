using AutoMapper;
using RPG_API.DAL.Entities;
using RPG_API.Models.DTOs.Weapon;

namespace RPG_API.BLL.Profiles;

public class WeaponProfile : Profile
{
    public WeaponProfile()
    {
        CreateMap<CreateWeaponDTO, Weapon>();
        CreateMap<UpdateWeaponDTO, Weapon>();
        CreateMap<Weapon, DisplayWeaponDTO>();
    }
}