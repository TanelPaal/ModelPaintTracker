using DAL;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Services;


public class BrandService : IBrandService
{
    private readonly ApplicationDbContext _context;

    public BrandService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Brand>> GetAllAsync()
    {
        return await _context.Brands.ToListAsync();
    }

    public async Task<Brand> GetByIdAsync(int id)
    {
        var brand = await _context.Brands.FindAsync(id);
        if (brand == null)
        {
            throw new KeyNotFoundException($"Brand with ID {id} not found");
        }
        return brand;
    }

    public async Task<Brand> CreateAsync(Brand brand)
    {
        _context.Brands.Add(brand);
        await _context.SaveChangesAsync();
        return brand;
    }

    public async Task UpdateAsync(Brand brand)
    {
        _context.Entry(brand).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var brand = await _context.Brands.FindAsync(id);
        if (brand == null)
        {
            throw new KeyNotFoundException($"Brand with ID {id} not found");
        }
        _context.Brands.Remove(brand);
        await _context.SaveChangesAsync();
    }
}