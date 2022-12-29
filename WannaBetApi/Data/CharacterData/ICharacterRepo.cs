using WannaBetApi.Models;

namespace WannaBetApi.Data;

public interface ICharacterRepo
{
    IEnumerable<Character> GetAllCharacters();
    Character GetCharacterById(int id);

}


