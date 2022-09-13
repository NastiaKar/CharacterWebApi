using AutoMapper;
using RPG_API.BLL.Extensions;
using RPG_API.DAL.Entities;
using RPG_API.Models.DTOs.Character;
using RPG_API.Models.DTOs.Skill;
using RPG_API.Models.DTOs.Weapon;

namespace RPG_API.BLL.Profiles;

public class CharacterProfile : Profile
{
    public CharacterProfile()
    {
        var mapper = new Mapper(new MapperConfiguration(config =>
            config.AddProfiles(new Profile[] {new WeaponProfile(), new SkillProfile()})));
        
        CreateMap<CreateCharacterDTO, Character>()
            .ForMember(dest => dest.RpgClass,
                options => options.MapFrom(c => c.RpgClass.ConvertToRpgClass()));

        CreateMap<UpdateCharacterDTO, Character>()
            .ForMember(dest => dest.RpgClass,
                options => options.MapFrom(c => c.RpgClass.ConvertToRpgClass()));
        
        CreateMap<Character, DisplayCharacterDTO>()
            .ForMember(dest => dest.Weapon, 
                options => options.MapFrom(c => mapper.Map<DisplayWeaponDTO>(c.Weapon)))
            .ForMember(dest => dest.Skills, 
                options => options.MapFrom(c => mapper.Map<List<DisplaySkillDTO>>(c.Skills)));
        
    }
}