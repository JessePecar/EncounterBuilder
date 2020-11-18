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
                currCharacter.Ability.CharacterId = currCharacter.CharacterId;
                _context.CharacterAbility.Add(currCharacter.Ability);
                _context.SaveChanges();
            }

        }
        public async Task CreateNewCharacterAction(CharacterActions currCharacter, string name)
        {
            try
            {
                Character charToUpdate = _context.Characters.FirstOrDefault(c => c.Name == name);

                long actionId = _context.CharacterActions.Where(ca => ca.CharacterAttack.Name == currCharacter.CharacterAttack.Name).Select(cs => cs.CharacterActionsId).FirstOrDefault();

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
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }

        }
        #endregion

        #region Read
        public async Task<List<Character>> GetCharacters()
        {
            List<Character> characters = new List<Character>();
            try
            {
                characters = await _context.Characters
                    .Include(c => c.Stats)
                    .Include(c => c.Actions).ThenInclude(a => a.Action).ThenInclude(ac => ac.CharacterAttack)
                    .Include(c => c.Ability)
                    .ToListAsync();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return characters;
        }

        public async Task<List<Character>> GetCharactersByName(string name)
        {
            List<Character> characters = new List<Character>();
            try
            {
                characters = await _context.Characters
                    .Include(c => c.Ability)
                    .Include(c => c.Actions)
                    .Include(c => c.Stats)
                    .Where(c => c.Name == name).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return characters;
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
