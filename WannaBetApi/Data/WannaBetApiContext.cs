using Microsoft.EntityFrameworkCore;
using WannaBetApi.Models;

namespace WannaBetApi.Data;

public class WannaBetApiContext : DbContext
{
    public WannaBetApiContext(DbContextOptions<WannaBetApiContext> opt) : base(opt)
    {

    }

    public DbSet<Character> Characters { get; set; }
}