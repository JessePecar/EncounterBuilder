using AutoMapper;
using EncounterBuilder.DAC.Models;
using System.Collections.Generic;
using System.Linq;

namespace EncounterBuilder.BusinessRules.Profiles
{
    public class CharacterProfiles : Profile
    {
        public CharacterProfiles()
        {
            CreateMap<Character, Models.Character.Character>()
                .ForMember(dest => dest.Actions, opt => opt.MapFrom(src => src.Actions != null ? src.Actions.Select(a => a.Action).ToList() : new List<CharacterActions>()))
                .ForMember(dest => dest.Ability, opt => opt.MapFrom(src => (src.Ability != null ? src.Ability : new CharacterAbility())))
                .ForMember(dest => dest.Stats, opt => opt.MapFrom(src => (src.Stats != null ? src.Stats : new CharacterStats())))
                .ReverseMap();

            //CreateMap<Models.Character.Character, Character>()
            //    .ForMember(dest => dest.Actions, opt => opt.MapFrom(src => src.Actions != null ? src.Actions.Select(a => a.Action).ToList() : new List<CharacterActions>()))
            //    .ForMember(dest => dest.Ability, opt => opt.MapFrom(src => (src.Ability != null ? src.Ability : new CharacterAbility())))
            //    .ForMember(dest => dest.Stats, opt => opt.MapFrom(src => (src.Stats != null ? src.Stats : new CharacterStats())))
            //    .ReverseMap();


            CreateMap<CharacterStats, Models.Character.CharacterStats>().ReverseMap();
            CreateMap<ActionsLink, Models.Character.CharacterActions>()
                .ForMember(dest => dest.CharacterAttack, opt => opt.MapFrom(src => src.Action.CharacterAttack))
                .ForMember(dest => dest.IsWeaponAttack, opt => opt.MapFrom(src => src.Action.IsWeaponAttack))
                .ReverseMap();
            CreateMap<CharacterAbility, Models.Character.CharacterAbility>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                ;

            CreateMap<Models.Character.CharacterAbility, CharacterAbility>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                ;

            CreateMap<Attack, Models.Weapons.Attack>().ReverseMap();

            CreateMap<Models.Character.CharacterActions, ActionsLink>()
                .ForMember(dest => dest.Action, opt => opt.MapFrom(src => src))
                .ReverseMap().ReverseMap();

            CreateMap<Models.Character.CharacterActions, CharacterActions>().ReverseMap();
        }
    }
}
