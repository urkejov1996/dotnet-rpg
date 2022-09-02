using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_dev.Dtos.Character;

namespace dotnet_dev.Services.CharacterService
{
    public interface ICharacterService
    {
         Task<ServiceResponse<List<GetCharacterDTO>>> GetAllCharacters();
        Task<ServiceResponse<GetCharacterDTO>> GetCharacterById(int id);
        Task<ServiceResponse<List<GetCharacterDTO>>> AddNewCharacter(AddCharacterDTO newCharacter);

        Task<ServiceResponse<GetCharacterDTO>> UpdateCharacter(UpdateCharacterDTO updatedCharacter);
    }
}