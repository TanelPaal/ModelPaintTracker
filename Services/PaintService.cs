using DAL;
using Domain;
using Microsoft.EntityFrameworkCore;
using Services;

public interface IPaintService : IBaseService<Paint>
{
    Task<IEnumerable<Paint>> GetPaintsByUserAsync(int userId);
    Task<IEnumerable<Paint>> GetPaintsByBrandAsync(int brandId);
    Task<IEnumerable<Paint>> GetAllWithDetailsAsync();
}

public class PaintService : BaseService<Paint>, IPaintService
{
    private readonly ApplicationDbContext _context;

    public PaintService(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Paint>> GetAllWithDetailsAsync()
    {
        return await _context.Paints
            .Include(p => p.Brand)
            .Include(p => p.PaintType)
            .ToListAsync();
    }

    public async Task<IEnumerable<Paint>> GetPaintsByBrandAsync(int brandId)
    {
        return await _context.Paints
            .Include(p => p.Brand)
            .Include(p => p.PaintType)
            .Where(p => p.BrandID == brandId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Paint>> GetPaintsByUserAsync(int userId)
    {
        return await _context.Paints
            .Include(p => p.Brand)
            .Include(p => p.PaintType)
            .Where(p => p.UserID == userId)
            .ToListAsync();
    }
} 