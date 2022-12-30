using WannaBetApi.Models;

namespace WannaBetApi.Data;

public interface ICharacterRepo
{
    bool SaveChanges();
    IEnumerable<Character> GetAllCharacters();
    Character GetCharacterById(int id);
    void CreateCharacter(Character character);
    void UpdateCharacter(Character character);
    void DeleteCharacter(Character character);
}


