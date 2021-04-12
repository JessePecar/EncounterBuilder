using AutoMapper;
using EncounterBuilder.DAC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EncounterBuilder.BusinessRules.Profiles
{
    public class CharacterProfiles : Profile
    {
        public CharacterProfiles()
        {
            CreateMap<Character, Models.Character.Character>()
                .ForMember(dest => dest.Actions, opt => opt.MapFrom(src => src.ActionsLinks.Select(al => al.CharacterActions) ?? new List<CharacterActions>()))
                .ForMember(dest => dest.Ability, opt => opt.MapFrom(src => src.CharacterAbilities.FirstOrDefault() ?? new CharacterAbility()))
                .ForMember(dest => dest.Stats, opt => opt.MapFrom(src => src.CharacterStats.FirstOrDefault() ?? new CharacterStats()))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CharacterId))
                .ForMember(dest => dest.Alignment, opt => opt.MapFrom(src => (long)src.Alignment))
                .ReverseMap();

            CreateMap<CharacterStats, Models.Character.CharacterStats>()
                .ForMember(dest => dest.Charisma, opt => opt.MapFrom(src => (int)src.Charisma))
                .ForMember(dest => dest.CharismaModifier, opt => opt.MapFrom(src => (int)src.CharismaModifier))
                .ForMember(dest => dest.Constitution, opt => opt.MapFrom(src => (int)src.Constitution))
                .ForMember(dest => dest.ConstitutionModifier, opt => opt.MapFrom(src => (int)src.ConstitutionModifier))
                .ForMember(dest => dest.Dexterity, opt => opt.MapFrom(src => (int)src.Dexterity))
                .ForMember(dest => dest.DexterityModifier, opt => opt.MapFrom(src => (int)src.DexterityModifier))
                .ForMember(dest => dest.Intelligence, opt => opt.MapFrom(src => (int)src.Intelligence))
                .ForMember(dest => dest.IntelligenceModifier, opt => opt.MapFrom(src => (int)src.IntelligenceModifier))
                .ForMember(dest => dest.Strength, opt => opt.MapFrom(src => (int)src.Strength))
                .ForMember(dest => dest.StrengthModifier, opt => opt.MapFrom(src => (int)src.StrengthModifier))
                .ForMember(dest => dest.Wisdom, opt => opt.MapFrom(src => (int)src.Wisdom))
                .ForMember(dest => dest.WisdomModifier, opt => opt.MapFrom(src => (int)src.WisdomModifier))
                .ReverseMap();

            CreateMap<ActionsLink, Models.Character.CharacterActions>()
                .ForMember(dest => dest.CharacterAttack, opt => opt.MapFrom(src => src.CharacterActions.CharacterAttack))
                .ForMember(dest => dest.IsWeaponAttack, opt => opt.MapFrom(src => src.CharacterActions.IsWeaponAttack))
                .ReverseMap();

            CreateMap<CharacterAbility, Models.Character.CharacterAbility>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                ;

            CreateMap<Models.Character.CharacterAbility, CharacterAbility>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                ;

            CreateMap<Attack, Models.Weapons.Attack>()
                .ForMember(dest => dest.SpellDamageType, opt => opt.MapFrom(src => (int)src.SpellDamageType))
                .ForMember(dest => dest.ThrowType, opt => opt.MapFrom(src => (int)src.ThrowType))
                .ForMember(dest => dest.DamageType, opt => opt.MapFrom(src => (int)src.DamageType))
                ;

            CreateMap<Models.Weapons.Attack, Attack>()
                .ForMember(dest => dest.SpellDamageType, opt => opt.MapFrom(src => (int)src.SpellDamageType))
                .ForMember(dest => dest.ThrowType, opt => opt.MapFrom(src => (int)src.ThrowType))
                .ForMember(dest => dest.DamageType, opt => opt.MapFrom(src => (int)src.DamageType))
                ;

            CreateMap<Models.Character.CharacterActions, ActionsLink>()
                .ForMember(dest => dest.CharacterActions, opt => opt.MapFrom(src => src))
                .ReverseMap();

            CreateMap<Models.Character.CharacterActions, CharacterActions>()
                .ForMember(dest => dest.CharacterAttack, opt => opt.MapFrom(src => src.CharacterAttack))
                .ReverseMap();

            CreateMap<Models.Campaign.Campaign, Campaign>().ReverseMap();

            CreateMap<EncounterLink, Models.Character.Character>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CharacterId))
                .ForMember(dest => dest.MaxHealth, opt => opt.MapFrom(src => src.CurrentHp))
                ;

            CreateMap<Models.Character.Character, EncounterLink>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CurrentHp, opt => opt.MapFrom(src => src.MaxHealth))
                .ForMember(dest => dest.CharacterId, opt => opt.MapFrom(src => src.Id));

            CreateMap<Encounter, Models.Campaign.Encounter>()
                .ForMember(dest => dest.EncounterCharacters, opt => opt.MapFrom(src => src.EncounterLinks))
                .ForMember(dest => dest.Campaign, opt => opt.MapFrom(src => src.Campaign))
                .ForMember(dest => dest.InitialCharacterCount, opt => opt.MapFrom(src => src.InitialCharacterCount))
                .ForPath(dest => dest.Campaign.Id, opt => opt.MapFrom(src => (src.Campaign.Id <= 0) ? 0 : src.Campaign.Id))
                .ReverseMap();

        }
    }
}
