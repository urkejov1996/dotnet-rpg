using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_dev.Dtos.Character;
using dotnet_dev.Services.CharacterService;
using Microsoft.AspNetCore.Mvc;


namespace dotnet_dev.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService characterService;
        public CharacterController(ICharacterService characterService)
        {
            this.characterService = characterService;

        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDTO>>>> Get()
        {
            return Ok(await characterService.GetAllCharacters());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDTO>>> GetSingle(int id)
        {
            return Ok(await characterService.GetCharacterById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDTO>>>> AddCharacter(AddCharacterDTO newCharacter)
        {
            return Ok(await characterService.AddNewCharacter(newCharacter));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<UpdateCharacterDTO>>> UpdateCharacter(UpdateCharacterDTO updatedCharacter)
        {
            var response = await characterService.UpdateCharacter(updatedCharacter);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}