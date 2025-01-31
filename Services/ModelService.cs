using DAL;
using Domain;
using Microsoft.EntityFrameworkCore;
using Services;

public interface IModelService : IBaseService<Model>
{
    Task<IEnumerable<Model>> GetModelsByUserAsync(int userId);
    Task<IEnumerable<Model>> GetModelsByFactionAsync(int factionId);
    Task<IEnumerable<Model>> GetModelsByStateAsync(int stateId);
    Task<IEnumerable<Model>> GetAllWithDetailsAsync();
    Task<Model?> GetByIdWithDetailsAsync(int id);
}

public class ModelService : BaseService<Model>, IModelService
{
    private readonly ApplicationDbContext _context;

    public ModelService(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Model>> GetModelsByUserAsync(int userId)
    {
        return await _context.Models
            .Include(m => m.Faction)
            .Include(m => m.State)
            .Include(m => m.ModelPaints)
                .ThenInclude(mp => mp.Paint)
            .Where(m => m.UserID == userId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Model>> GetModelsByFactionAsync(int factionId)
    {
        return await _context.Models
            .Include(m => m.State)
            .Where(m => m.FactionID == factionId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Model>> GetModelsByStateAsync(int stateId)
    {
        return await _context.Models
            .Include(m => m.Faction)
            .Where(m => m.StateID == stateId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Model>> GetAllWithDetailsAsync()
    {
        return await _context.Models
            .Include(m => m.Faction)
            .Include(m => m.State)
            .ToListAsync();
    }

    public async Task<Model?> GetByIdWithDetailsAsync(int id)
    {
        return await _context.Models
            .Include(m => m.Faction)
            .Include(m => m.State)
            .FirstOrDefaultAsync(m => m.ModelID == id);
    }
} 