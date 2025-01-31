using DAL;
using Domain;
using Microsoft.EntityFrameworkCore;
using Services;

public interface IPaintService : IBaseService<Paint>
{
    Task<IEnumerable<Paint>> GetPaintsByUserAsync(int userId);
    Task<IEnumerable<Paint>> GetPaintsByBrandAsync(int brandId);
}

public class PaintService : BaseService<Paint>, IPaintService
{
    public PaintService(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Paint>> GetPaintsByUserAsync(int userId)
    {
        return await _context.Paints
            .Include(p => p.Brand)
            .Include(p => p.PaintType)
            .Where(p => p.UserID == userId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Paint>> GetPaintsByBrandAsync(int brandId)
    {
        return await _context.Paints
            .Include(p => p.PaintType)
            .Where(p => p.BrandID == brandId)
            .ToListAsync();
    }
} 