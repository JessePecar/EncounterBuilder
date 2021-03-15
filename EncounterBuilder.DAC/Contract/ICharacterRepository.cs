using EncounterBuilder.DAC.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EncounterBuilder.DAC.Contract
{
    public interface ICharacterRepository
    {
        List<Character> GetCharacters();
        List<Character> GetCharactersByName(string name);
        List<Character> GetCharactersByIds(List<Tuple<int, int>> characters);
        List<Campaign> GetCampaigns();
        List<Encounter> GetEncounters();
        Task AddEncounter(Encounter encounter);
        Task CreateNewCharacter(Character newCharacter);
        Task CreateNewCharacterAbility(Character currCharacter);
        Task CreateNewCharacterAction(CharacterActions currCharacter, string name);
        Task UpdateCharacter(Character updCharacter);
        Task DeleteCharacter(Character delCharacter);
    }
}
