using Domain;

namespace Services;

public interface IPaintTypeService
{
    Task<IEnumerable<PaintType>> GetAllAsync();
    Task<PaintType> GetByIdAsync(int id);
    Task<PaintType> CreateAsync(PaintType paintType);
    Task UpdateAsync(PaintType paintType);
    Task DeleteAsync(int id);
} 