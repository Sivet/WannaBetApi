using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WannaBetApi.Data;
using WannaBetApi.Dtos;
using WannaBetApi.Models;

namespace WannaBetApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CharactersController : ControllerBase
{
    private readonly ICharacterRepo _repository;
    private readonly IMapper _mapper;

    public CharactersController(ICharacterRepo repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<CharacterOutputDto>> GetAllCharacters()
    {
        var characters = _repository.GetAllCharacters();
        return Ok(_mapper.Map<IEnumerable<CharacterOutputDto>>(characters));
    }

    [HttpGet("{id}", Name = "GetCharacterById")] //Named so the post can use it. Should not be needed?
    public ActionResult<CharacterOutputDto> GetCharacterById(int id)
    {
        try
        {
            var character = _repository.GetCharacterById(id);
            return Ok(_mapper.Map<CharacterOutputDto>(character));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost]
    public ActionResult<CharacterOutputDto> CreateCharacter(CharacterInputDto newCharacter)
    {
        var characterModel = _mapper.Map<Character>(newCharacter);
        _repository.CreateCharacter(characterModel);
        _repository.SaveChanges();

        var characterOutputDto = _mapper.Map<CharacterOutputDto>(characterModel);

        return CreatedAtRoute(nameof(GetCharacterById), new { Id = characterOutputDto.Id }, characterOutputDto);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateCharacter(int id, CharacterInputDto inputCharacter)
    {
        try
        {
            var currentCharacterModel = _repository.GetCharacterById(id);

            _mapper.Map(inputCharacter, currentCharacterModel); //This updates the EF internal memory so no need for logic in the sql update
            _repository.UpdateCharacter(currentCharacterModel); //Empty call
            _repository.SaveChanges();
            return NoContent();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteCharacter(int id)
    {
        try
        {
            var currentCharacterModel = _repository.GetCharacterById(id);

            _repository.DeleteCharacter(currentCharacterModel);
            _repository.SaveChanges();
            return NoContent();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}