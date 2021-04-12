using AutoMapper;
using EncounterBuilder.BusinessRules.Contracts;
using EncounterBuilder.Models.Campaign;
using EncounterBuilder.Models.Character;
using EncounterBuilder.Models.Saves;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public async Task AddNewCampaign(Campaign newCampaign)
        {
            try
            { 

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddEncounter(Encounter newEncounter)
        {
            try
            {
                DAC.Models.Encounter dbEncounter = _mapper.Map<DAC.Models.Encounter>(newEncounter);
                await _repository.AddEncounter(dbEncounter);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Read

        public List<Character> GetAllCharacters()
        {
            try
            {
                List<Character> characters = _mapper.Map<List<DAC.Models.Character>, List<Character>>(_repository.GetCharacters());
                return characters;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Character GetCharacterByName(string Name)
        {
            try
            {
                List<Character> characters = _mapper.Map<List<DAC.Models.Character>, List<Character>>(_repository.GetCharactersByName(Name));

                return characters.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Campaign> GetCampaigns(bool isSelector = true)
        {
            try
            {
                List<Campaign> campaigns = new List<Campaign>();
                if (isSelector)
                {
                    campaigns.AddRange(new List<Campaign>()
                    {
                        new Campaign(){ Id = -1, Name = "-- Select Campaign --" },
                        new Campaign(){ Id = -69, Name = "Create new campaign." }
                    });
                }
                List<DAC.Models.Campaign> databaseCampaigns = _repository.GetCampaigns();

                if(databaseCampaigns != null)
                {
                    campaigns.AddRange(_mapper.Map<List<DAC.Models.Campaign>, List<Campaign>>(databaseCampaigns));
                }

                return campaigns;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<Encounter> GetEncounters()
        {
            try
            {
                List<Encounter> encounters = _mapper.Map<List<Encounter>>(_repository.GetEncounters());
                encounters.ForEach(e =>
                {
                    List<Tuple<int, int>> tempChars = new List<Tuple<int, int>>();
                    e.EncounterCharacters.ForEach(ec => 
                    {
                        tempChars.Add(new Tuple<int, int>((int)ec.Id, ec.MaxHealth));
                    });
                    e.EncounterCharacters = _mapper.Map<List<Character>>(_repository.GetCharactersByIds(tempChars));
                });
                return encounters;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        #endregion

        #region Update

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

        #region Delete

        public async Task DeleteCharacter(Character deletedCharacter)
        {
            try
            {
                _repository.DeleteCharacter(_mapper.Map<DAC.Models.Character>(deletedCharacter));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
