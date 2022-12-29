using WannaBetApi.Models;

namespace WannaBetApi.Data;

public class MockCharacterRepo : ICharacterRepo
{
    static IEnumerable<Character> characters = new List<Character>
    {
        new Character{Id=0, Name="Sali", Class="Monk", Role="Healer"},
        new Character{Id=1, Name="Kusa", Class="Paladin", Role="Healer"},
        new Character{Id=2, Name="Link", Class="Paladin", Role="Dps"},
        new Character{Id=3, Name="Neesh", Class="DeathKnight", Role="Tank"}
    };
    public IEnumerable<Character> GetAllCharacters()
    {
        return characters;
    }

    public Character GetCharacterById(int id)
    {
        return characters.FirstOrDefault(i => i.Id == id) ?? new Character { Id = id };
    }
}


