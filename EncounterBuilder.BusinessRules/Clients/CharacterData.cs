using EncounterBuilder.BusinessRules.Contracts;
using EncounterBuilder.Models.Character;
using EncounterBuilder.Models.Saves;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace EncounterBuilder.BusinessRules.Clients
{
    public class CharacterData : ICharacterRepository
    {
        private readonly Dictionary<JsonTypes, string> _jsonDirectory = new Dictionary<JsonTypes, string>();

        public CharacterData()
        {
            _jsonDirectory.Add(JsonTypes.Character, Path.Combine(Directory.GetCurrentDirectory(), @"..\EncounterBuilder.BusinessRules\CharacterJson\createdCharacters.json"));
            _jsonDirectory.Add(JsonTypes.Spell, Path.Combine(Directory.GetCurrentDirectory(), @"..\EncounterBuilder.BusinessRules\CharacterJson\createdSpells.json"));
            _jsonDirectory.Add(JsonTypes.Weapon, Path.Combine(Directory.GetCurrentDirectory(), @"..\EncounterBuilder.BusinessRules\CharacterJson\createdWeapons.json"));

            VerifyFiles();
        }

        #region Write

        public async Task AddToCharacterList(Character newCharacter)
        {
            List<Character> currentCharacters = await ResetJson(JsonTypes.Character, newCharacter);
            KeyValuePair<JsonTypes, string> characterSave = new KeyValuePair<JsonTypes, string>(JsonTypes.Character, JsonConvert.SerializeObject(currentCharacters));

            await SaveToJson(characterSave);
        }

        public async Task UpdateCurrentCharacter(Character updCharacter)
        {
            List<Character> currentCharacters = await ResetJson(JsonTypes.Character);
            currentCharacters.RemoveAll(ch => ch.Name == updCharacter.Name);
            currentCharacters.Add(updCharacter);

            KeyValuePair<JsonTypes, string> characterSave = new KeyValuePair<JsonTypes, string>(JsonTypes.Character, JsonConvert.SerializeObject(currentCharacters));

            await SaveToJson(characterSave);
        }

        #endregion

        #region Read

        public async Task<List<Character>> GetAllCharacters()
        {
            try
            {
                string characters = string.Empty;
                using (StreamReader reader = new StreamReader(_jsonDirectory[JsonTypes.Character]))
                {
                    characters = reader.ReadToEnd();
                }


                return JsonConvert.DeserializeObject<List<Character>>(characters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Delete

        public async Task DeleteCharacter(Character deletedCharacter)
        {
            List<Character> currentCharacters = await ResetJson(JsonTypes.Character);
            currentCharacters.RemoveAll(ch => ch.Name == deletedCharacter.Name);

            KeyValuePair<JsonTypes, string> characterSave = new KeyValuePair<JsonTypes, string>(JsonTypes.Character, JsonConvert.SerializeObject(currentCharacters));

            await SaveToJson(characterSave);
        }
        #endregion

        #region helper methods

        private void VerifyFiles()
        {
            foreach (KeyValuePair<JsonTypes, string> jsonFile in _jsonDirectory)
            {
                if (!File.Exists(jsonFile.Value)) File.Create(jsonFile.Value);
            }
        }

        private async Task SaveToJson(KeyValuePair<JsonTypes, string> jsonFile)
        {
            using (StreamWriter write = new StreamWriter(_jsonDirectory.GetValueOrDefault(jsonFile.Key)))
            {
                await write.WriteAsync(jsonFile.Value);
            }
        }

        private async Task<List<Character>> ResetJson(JsonTypes fileKey, Character newCharacter = null)
        {
            string characters = string.Empty;
            using (StreamReader reader = new StreamReader(_jsonDirectory.GetValueOrDefault(fileKey)))
            {
                characters = reader.ReadToEnd();
            }

            if (File.Exists(_jsonDirectory[fileKey]))
            {
                File.Delete(_jsonDirectory[fileKey]);
            }
            using (FileStream fs = File.Create(_jsonDirectory[fileKey]))
            {
            }

            List<Character> savedCharacters = JsonConvert.DeserializeObject<List<Character>>(characters);
            if (newCharacter != null)
            {
                savedCharacters?.Add(newCharacter);
            }
            return savedCharacters;
        }
        #endregion
    }
}
