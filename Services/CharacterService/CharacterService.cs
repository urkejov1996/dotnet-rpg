using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_dev.Dtos.Character;

namespace dotnet_dev.Services.CharacterService
{

    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character>{
            new Character(),
            new Character{Id=1, Name = "Sam"}
        };
        private readonly IMapper mapper;

        public CharacterService(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetCharacterDTO>>> AddNewCharacter(AddCharacterDTO newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDTO>>();
            Character character = mapper.Map<Character>(newCharacter);
            character.Id = characters.Max(c => c.Id) + 1;
            characters.Add(character);
            serviceResponse.Data = characters.Select(c => mapper.Map<GetCharacterDTO>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDTO>>> GetAllCharacters()
        {
            return new ServiceResponse<List<GetCharacterDTO>>
            {
                Data = characters.Select(c => mapper.Map<GetCharacterDTO>(c)).ToList()
            };
        }

        public async Task<ServiceResponse<GetCharacterDTO>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDTO>();
            var character = characters.FirstOrDefault(c => c.Id == id);
            serviceResponse.Data = mapper.Map<GetCharacterDTO>(character);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDTO>> UpdateCharacter(UpdateCharacterDTO updatedCharacter)
        {
            ServiceResponse<GetCharacterDTO> response = new ServiceResponse<GetCharacterDTO>();

            try
            {
                Character character = characters.FirstOrDefault(c => c.Id == updatedCharacter.Id);

                character.Name = updatedCharacter.Name;
                character.HitPoints = updatedCharacter.HitPoints;
                character.Strenght = updatedCharacter.Strenght;
                character.Defense = updatedCharacter.Strenght;
                character.Intelligence = updatedCharacter.Intelligence;
                character.Class = updatedCharacter.Class;

                response.Data = mapper.Map<GetCharacterDTO>(character);
                response.Message = "Your character has been saved :)";
            }
            catch (Exception ex)
            {
                response.Success =false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}