
using EncounterBuilder.Models.Campaign;
using EncounterBuilder.Models.Character;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EncounterBuilder.BusinessRules.Contracts
{
    public interface ICharacterRepository
    {
        Task AddToCharacterList(Character newCharacter);

        List<Character> GetAllCharacters();

        Character GetCharacterByName(string Name);

        List<Campaign> GetCampaigns(bool isSelector = true);

        List<Encounter> GetEncounters();

        Task AddEncounter(Encounter newEncounter);

        Task UpdateCurrentCharacter(Character updCharacter);

        Task DeleteCharacter(Character deletedCharacter);
    }
}
