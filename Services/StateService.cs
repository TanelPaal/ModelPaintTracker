using DAL;
using Domain;
using Microsoft.EntityFrameworkCore;
using Services;

public interface IStateService : IBaseService<State>
{
    Task<IEnumerable<State>> GetStatesWithModelsAsync();
}

public class StateService : BaseService<State>, IStateService
{
    public StateService(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<State>> GetStatesWithModelsAsync()
    {
        return await _context.States
            .Include(s => s.Models)
            .ToListAsync();
    }
} 