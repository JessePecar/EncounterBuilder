
using EncounterBuilder.Models.Character;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EncounterBuilder.BusinessRules.Contracts
{
    public interface ICharacterRepository
    {
        Task AddToCharacterList(Character newCharacter);

        Task<List<Character>> GetAllCharacters();
        Task<Character> GetCharacterByName(string Name);

        Task UpdateCurrentCharacter(Character updCharacter);

        Task DeleteCharacter(Character deletedCharacter);
    }
}
