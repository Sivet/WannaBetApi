using WannaBetApi.Models;

namespace WannaBetApi.Data;

public class SqlCharacterRepo : ICharacterRepo
{
    private readonly WannaBetApiContext _context;

    public SqlCharacterRepo(WannaBetApiContext context)
    {
        _context = context;
    }
    public IEnumerable<Character> GetAllCharacters()
    {
        return _context.Characters.ToList();
    }

    public Character GetCharacterById(int id)
    {
        return _context.Characters.FirstOrDefault(c => c.Id == id) ?? throw new ArgumentNullException("Character of Id " + id + " is not found");
    }
}