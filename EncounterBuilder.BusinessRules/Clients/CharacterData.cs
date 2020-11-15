using EncounterBuilder.BusinessRules.Contracts;
using EncounterBuilder.Models.Saves;
using System.Collections.Generic;
using System.IO;

namespace EncounterBuilder.BusinessRules.Clients
{
    public class CharacterData : ICharacterRepository
    {
        private readonly Dictionary<JsonTypes, string> _jsonDirectory = new Dictionary<JsonTypes, string>();

        public CharacterData()
        {
            _jsonDirectory.Add( JsonTypes.Character,Path.Combine(Directory.GetCurrentDirectory(), @"..\EncounterBuilder.BusinessRules\CharacterJson\createdCharacters.json"));
            _jsonDirectory.Add( JsonTypes.Spell,Path.Combine(Directory.GetCurrentDirectory(), @"..\EncounterBuilder.BusinessRules\CharacterJson\createdSpells.json"));
            _jsonDirectory.Add( JsonTypes.Weapon, Path.Combine(Directory.GetCurrentDirectory(), @"..\EncounterBuilder.BusinessRules\CharacterJson\createdWeapons.json"));

            VerifyFiles();
        }

        #region helper methods

        private void VerifyFiles()
        {
            foreach(KeyValuePair<JsonTypes, string> jsonFile in _jsonDirectory)
            {
                if (!File.Exists(jsonFile.Value)) File.Create(jsonFile.Value);
            }
        }

        private void SaveToJson(KeyValuePair<JsonTypes, string> jsonFile)
        {
            using(StreamWriter write = new StreamWriter(_jsonDirectory.GetValueOrDefault(jsonFile.Key)))
            {
                write.WriteAsync(jsonFile.Value);
            }
        }
        #endregion
    }
}
