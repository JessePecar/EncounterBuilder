using AutoMapper;
using EncounterBuilder.BusinessRules.Contracts;
using EncounterBuilder.DAC;
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
        private readonly DAC.Contract.ICharacterRepository _repository;
        private readonly IMapper _mapper;
        public CharacterData(DAC.Contract.ICharacterRepository repository, IMapper mapper)
        {
            _jsonDirectory.Add(JsonTypes.Character, Path.Combine(Directory.GetCurrentDirectory(), @"..\EncounterBuilder.BusinessRules\CharacterJson\createdCharacters.json"));
            _jsonDirectory.Add(JsonTypes.Spell, Path.Combine(Directory.GetCurrentDirectory(), @"..\EncounterBuilder.BusinessRules\CharacterJson\createdSpells.json"));
            _jsonDirectory.Add(JsonTypes.Weapon, Path.Combine(Directory.GetCurrentDirectory(), @"..\EncounterBuilder.BusinessRules\CharacterJson\createdWeapons.json"));

            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        }

        #region Create

        public async Task AddToCharacterList(Character newCharacter)
        {
            try
            {
                await _repository.CreateNewCharacter(_mapper.Map<DAC.Models.Character>(newCharacter));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateCurrentCharacter(Character updCharacter)
        {
            try
            {
                await _repository.UpdateCharacter(_mapper.Map<DAC.Models.Character>(updCharacter));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Read

        public async Task<List<Character>> GetAllCharacters()
        {
            try
            {
                List<Character> characters = _mapper.Map<List<DAC.Models.Character>, List<Character>>(await _repository.GetCharacters());

                return characters;
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
            try
            {
                _repository.DeleteCharacter(_mapper.Map<DAC.Models.Character>(deletedCharacter))
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #endregion
    }
}
