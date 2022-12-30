using WannaBetApi.Models;

namespace WannaBetApi.Data;

public class SqlCharacterRepo : ICharacterRepo
{
    private readonly WannaBetApiContext _context;

    public SqlCharacterRepo(WannaBetApiContext context)
    {
        _context = context;
    }
    public void CreateCharacter(Character character)
    {
        if (character == null)
        {
            throw new ArgumentNullException(nameof(character));
        }
        _context.Characters.Add(character);
    }

    public void DeleteCharacter(Character character)
    {
        if (character == null)
        {
            throw new ArgumentNullException(nameof(character));
        }
        _context.Characters.Remove(character);
    }

    public IEnumerable<Character> GetAllCharacters()
    {
        return _context.Characters.ToList();
    }

    public Character GetCharacterById(int id)
    {
        return _context.Characters.FirstOrDefault(c => c.Id == id) ?? throw new ArgumentNullException("Character of Id " + id + " is not found");
    }

    public bool SaveChanges()
    {
        return (_context.SaveChanges()) <= 0;
    }

    public void UpdateCharacter(Character character)
    {
        if (character == null)
        {
            throw new ArgumentNullException(nameof(character));
        }
        _context.Characters.Remove(character);
    }
}