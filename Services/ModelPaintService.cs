using DAL;
using Domain;
using Microsoft.EntityFrameworkCore;
using Services;

public interface IModelPaintService : IBaseService<ModelPaint>
{
    Task<IEnumerable<ModelPaint>> GetByModelIdAsync(int modelId);
    Task<IEnumerable<ModelPaint>> GetByPaintIdAsync(int paintId);
    Task<bool> ExistsAsync(int modelId, int paintId);
    Task DeleteAsync(int modelId, int paintId);
    Task<IEnumerable<ModelPaint>> GetByModelIdWithDetailsAsync(int modelId);
}

public class ModelPaintService : BaseService<ModelPaint>, IModelPaintService
{
    private readonly ApplicationDbContext _context;

    public ModelPaintService(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ModelPaint>> GetByModelIdAsync(int modelId)
    {
        return await _context.ModelPaints
            .Include(mp => mp.Paint)
            .Where(mp => mp.ModelID == modelId)
            .ToListAsync();
    }

    public async Task<IEnumerable<ModelPaint>> GetByPaintIdAsync(int paintId)
    {
        return await _context.ModelPaints
            .Include(mp => mp.Model)
            .Where(mp => mp.PaintID == paintId)
            .ToListAsync();
    }

    public async Task<bool> ExistsAsync(int modelId, int paintId)
    {
        return await _context.ModelPaints
            .AnyAsync(mp => mp.ModelID == modelId && mp.PaintID == paintId);
    }
    
    public async Task DeleteAsync(int modelId, int paintId)
    {
        var modelPaint = await _context.ModelPaints
            .FirstOrDefaultAsync(mp => mp.ModelID == modelId && mp.PaintID == paintId);
            
        if (modelPaint != null)
        {
            _context.ModelPaints.Remove(modelPaint);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<ModelPaint>> GetByModelIdWithDetailsAsync(int modelId)
    {
        return await _context.ModelPaints
            .Include(mp => mp.Paint)
                .ThenInclude(p => p!.Brand)
            .Include(mp => mp.Paint)
                .ThenInclude(p => p!.PaintType)
            .Where(mp => mp.ModelID == modelId)
            .ToListAsync();
    }
}