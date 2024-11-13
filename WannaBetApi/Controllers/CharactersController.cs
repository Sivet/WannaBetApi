using Microsoft.AspNetCore.Mvc;
using WannaBetApi.Dtos;
using WannaBetApi.Services;

namespace WannaBetApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CharactersController : ControllerBase
{
    private readonly CharacterService _service;

    public CharactersController(CharacterService service/*ICharacterRepo repository, IMapper mapper*/)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<IEnumerable<CharacterOutputDto>> GetAllCharacters()
    {
        return Ok(_service.GetAllCharacters());
    }

    [HttpGet("{id}", Name = "GetCharacterById")] //Named so the post can use it. Should not be needed?
    public ActionResult<CharacterOutputDto> GetCharacterById(int id)
    {
        try
        {
            return Ok(_service.GetCharacterById(id));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost]
    public ActionResult<CharacterOutputDto> CreateCharacter(CharacterInputDto newCharacter)
    {
        var characterOutputDto = _service.CreateCharacter(newCharacter);

        return CreatedAtRoute(nameof(GetCharacterById), new { Id = characterOutputDto.Id }, characterOutputDto);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateCharacter(int id, CharacterInputDto inputCharacter)
    {
        if (_service.UpdateCharacter(id, inputCharacter) == false)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteCharacter(int id)
    {
        if (_service.DeleteCharacter(id) == false)
        {
            return NotFound();
        }
        return NoContent();
    }
}