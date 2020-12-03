using EncounterBuilder.DAC.Contract;
using EncounterBuilder.DAC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EncounterBuilder.DAC.Client
{
    public class CharacterData : ICharacterRepository
    {
        private readonly EncounterBuilderDbContext _context;
        public CharacterData(EncounterBuilderDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        #region Create
        public async Task CreateNewCharacter(Character newCharacter)
        {
            try
            {
                _context.Characters.Add(newCharacter);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task CreateNewCharacterAbility(Character currCharacter)
        {
            Character charToUpdate = _context.Characters.FirstOrDefault(c => c.Name == currCharacter.Name);

            if (charToUpdate != null)
            {
                currCharacter.CharacterAbilities.FirstOrDefault().CharacterId = currCharacter.CharacterId;
                _context.CharacterAbility.Add(currCharacter.CharacterAbilities.FirstOrDefault());
                _context.SaveChanges();
            }

        }
        public async Task CreateNewCharacterAction(CharacterActions currCharacter, string name)
        {
            try
            {
                Character charToUpdate = _context.Characters.FirstOrDefault(c => c.Name == name);

                long actionId = _context.CharacterActions
                    .Where(ca => ca.CharacterAttack.Name == currCharacter.CharacterAttack.Name)
                    .Select(cs => cs.CharacterActionsId)
                    .FirstOrDefault();

                if (charToUpdate != null)
                {

                    var link = new ActionsLink()
                    {
                        CharacterId = charToUpdate.CharacterId,
                        CharacterActionsId = actionId
                    };
                    _context.ActionsLink.Add(link);
                    _context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }

        }

        public async Task AddEncounter(Encounter encounter)
        {
            try
            {
                if(!_context.Campaigns?.Any(c => c.Id == encounter.CampaignId) ?? false)
                {
                    encounter.Campaign.Id = 0;
                    _context.Campaigns.Add(encounter.Campaign);
                    _context.SaveChanges();

                    encounter.CampaignId = _context.Campaigns.FirstOrDefault(c => c.Name == encounter.Campaign.Name).Id;
                }
                encounter.Campaign = null;
                _context.Campaigns.FirstOrDefault(c => c.Id == encounter.CampaignId)?.Encounters.Add(encounter);
                
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Read
        public List<Character> GetCharacters()
        {
            List<Character> characters = new List<Character>();
            try
            {
                characters = _context.Characters
                    .Include(c => c.CharacterStats)
                    .Include(c => c.ActionsLinks)
                    .ThenInclude(a => a.CharacterActions)
                    .ThenInclude(ac => ac.CharacterAttack)
                    .Include(c => c.CharacterAbilities)
                    .ToList();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return characters;
        }

        public List<Character> GetCharactersByName(string name)
        {
            List<Character> characters = new List<Character>();
            try
            {
                characters = _context.Characters
                    .Include(c => c.CharacterStats)
                    .Include(c => c.ActionsLinks)
                    .ThenInclude(a => a.CharacterActions)
                    .ThenInclude(ac => ac.CharacterAttack)
                    .Include(c => c.CharacterAbilities).Where(c => c.Name.Equals(name))
                    .ToList();

                characters = characters.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return characters;
        }

        public List<Campaign> GetCampaigns()
        {
            List<Campaign> campaigns = new List<Campaign>();
            try
            {
                campaigns = _context.Campaigns.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return campaigns;
        }
        #endregion

        #region Update
        public async Task UpdateCharacter(Character updCharacter)
        {
            try
            {
                Character charToUpdate = _context.Characters.FirstOrDefault(c => c.Name == updCharacter.Name);

                if (charToUpdate != null)
                {
                    updCharacter.CharacterId = charToUpdate.CharacterId;
                    _context.Entry(charToUpdate).CurrentValues.SetValues(updCharacter);
                    _context.Entry(charToUpdate).State = EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        #region Delete
        public async Task DeleteCharacter(Character delCharacter)
        {
            try
            {
                Character charToDelete = _context.Characters.FirstOrDefault(c => c.Name == delCharacter.Name);
                _context.Characters.Remove(charToDelete);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion

    }
}
