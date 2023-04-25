using AutoMapper;
using WannaBetApi.Data;
using WannaBetApi.Dtos;
using WannaBetApi.Models;

namespace WannaBetApi.Services;

public class CharacterService : ICharacterService
{
    private readonly ICharacterRepo _repository;
    private readonly IMapper _mapper;

    public CharacterService(ICharacterRepo repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public IEnumerable<CharacterOutputDto> GetAllCharacters()
    {
        var characters = _repository.GetAllCharacters();
        return _mapper.Map<IEnumerable<CharacterOutputDto>>(characters);
    }

    public CharacterOutputDto GetCharacterById(int id)
    {
        var character = _repository.GetCharacterById(id);
        if (character == null)
        {
            throw new NullReferenceException();
        }
        return _mapper.Map<CharacterOutputDto>(character);
    }

    public CharacterOutputDto CreateCharacter(CharacterInputDto newCharacter)
    {
        var characterModel = _mapper.Map<Character>(newCharacter);
        _repository.CreateCharacter(characterModel);
        _repository.SaveChanges();

        return _mapper.Map<CharacterOutputDto>(characterModel);

        //return CreatedAtRoute(nameof(GetCharacterById), new { Id = characterOutputDto.Id }, characterOutputDto);
    }

    public bool UpdateCharacter(int id, CharacterInputDto inputCharacter)
    {
        //Check if it is there to be updated
        var CharacterFromRepo = _repository.GetCharacterById(id);
        if (CharacterFromRepo == null)
        {
            return false;
        }

        var currentCharacterModel = _repository.GetCharacterById(id);

        _mapper.Map(inputCharacter, currentCharacterModel); //This updates the EF internal memory so no need for logic in the sql update
        _repository.UpdateCharacter(currentCharacterModel); //Empty call
        _repository.SaveChanges();
        return true;
    }

    public bool DeleteCharacter(int id)
    {
        //Check if it is there to be deleted
        var CharacterFromRepo = _repository.GetCharacterById(id);
        if (CharacterFromRepo == null)
        {
            return false;
        }

        _repository.DeleteCharacter(CharacterFromRepo);
        _repository.SaveChanges();
        return true;
    }
}