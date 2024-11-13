using WannaBetApi.Dtos;

namespace WannaBetApi.Services;

public interface ICharacterService
{
    IEnumerable<CharacterOutputDto> GetAllCharacters();
    CharacterOutputDto GetCharacterById(int id);
    CharacterOutputDto CreateCharacter(CharacterInputDto character);
    bool UpdateCharacter(int id, CharacterInputDto character);
    bool DeleteCharacter(int id);
}