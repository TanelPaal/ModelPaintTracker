using DAL;
using Domain;
using Microsoft.EntityFrameworkCore;
using Services;

public interface IFactionService : IBaseService<Faction>
{
    Task<IEnumerable<Faction>> GetFactionsWithModelsAsync();
}

public class FactionService : BaseService<Faction>, IFactionService
{
    public FactionService(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Faction>> GetFactionsWithModelsAsync()
    {
        return await _context.Factions
            .Include(f => f.Models)
            .ToListAsync();
    }
} 