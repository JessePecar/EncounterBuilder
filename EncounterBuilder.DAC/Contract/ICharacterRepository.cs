using EncounterBuilder.DAC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EncounterBuilder.DAC.Contract
{
    public interface ICharacterRepository
    {
        Task<List<Character>> GetCharacters();
        Task<List<Character>> GetCharactersByName(string name);
        Task CreateNewCharacter(Character newCharacter);
        Task CreateNewCharacterAbility(Character currCharacter);
        Task CreateNewCharacterAction(CharacterActions currCharacter, string name);
        Task UpdateCharacter(Character updCharacter);
        Task DeleteCharacter(Character delCharacter);
    }
}
