using Domain;

namespace Services;

public interface IBrandService
{
    Task<IEnumerable<Brand>> GetAllAsync();
    Task<Brand> GetByIdAsync(int id);
    Task<Brand> CreateAsync(Brand brand);
    Task UpdateAsync(Brand brand);
    Task DeleteAsync(int id);
} 