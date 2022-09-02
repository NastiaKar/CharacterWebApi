using AutoMapper;
using RPG_API.DAL.Entities;
using RPG_API.Models.DTOs.Skill;

namespace RPG_API.BLL.Profiles;

public class SkillProfile : Profile
{
    public SkillProfile()
    {
        CreateMap<CreateSkillDTO, Skill>();
        CreateMap<UpdateSkillDTO, Skill>();
        CreateMap<Skill, DisplaySkillDTO>();
    }
}