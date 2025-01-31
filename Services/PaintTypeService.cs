using DAL;
using Domain;
using Microsoft.EntityFrameworkCore;
using Services;
using Microsoft.Extensions.Logging;

public interface IPaintTypeService : IBaseService<PaintType>
{
    Task<IEnumerable<PaintType>> GetPaintTypesWithPaintsAsync();
}

public class PaintTypeService : BaseService<PaintType>, IPaintTypeService
{
    private readonly ILogger<PaintTypeService> _logger;

    public PaintTypeService(
        ILogger<PaintTypeService> logger,
        ApplicationDbContext context) : base(context)
    {
        _logger = logger;
    }

    public async Task<IEnumerable<PaintType>> GetPaintTypesWithPaintsAsync()
    {
        return await _context.PaintTypes
            .Include(pt => pt.Paints)
            .ToListAsync();
    }

    public override async Task<IEnumerable<PaintType>> GetAllAsync()
    {
        try
        {
            return await _context.PaintTypes
                .AsNoTracking()
                .ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting all paint types");
            throw;
        }
    }

    public override async Task<PaintType?> GetByIdAsync(int id)
    {
        try
        {
            return await _context.PaintTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(pt => pt.PaintTypeID == id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting paint type with ID {Id}", id);
            throw;
        }
    }

    public override async Task<PaintType> CreateAsync(PaintType paintType)
    {
        try
        {
            await _context.PaintTypes.AddAsync(paintType);
            await _context.SaveChangesAsync();
            return paintType;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating paint type");
            throw;
        }
    }

    public override async Task UpdateAsync(PaintType paintType)
    {
        try
        {
            _context.PaintTypes.Update(paintType);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating paint type");
            throw;
        }
    }

    public override async Task DeleteAsync(int id)
    {
        try
        {
            var paintType = await GetByIdAsync(id);
            if (paintType != null)
            {
                _context.PaintTypes.Remove(paintType);
                await _context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting paint type with ID {Id}", id);
            throw;
        }
    }
} 