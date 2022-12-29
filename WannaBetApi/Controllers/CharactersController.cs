using Microsoft.AspNetCore.Mvc;
using WannaBetApi.Data;
using WannaBetApi.Models;

namespace WannaBetApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CharactersController : ControllerBase
{
    private readonly ICharacterRepo _repository;
    public CharactersController(ICharacterRepo repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Character>> GetAllCharacters()
    {
        var characters = _repository.GetAllCharacters();
        return Ok(characters);
    }

    [HttpGet("{id}")]
    public ActionResult<Character> GetCharacterById(int id)
    {
        try
        {
            var character = _repository.GetCharacterById(id);
            return Ok(character);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}