using Microsoft.EntityFrameworkCore;
using PitStopConcurrency.Domain.Entities;
using PitStopConcurrency.Domain.Interfaces;
using PitStopConcurrency.Infrastructure.Persistence;

namespace PitStopConcurrency.Infrastructure.Repositories;

public class RaceRepository : IRaceRepository
{
    private readonly PitStopDbContext _dbContext;

    public RaceRepository(PitStopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task AddAsync(Race race)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Race>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Race?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Races
            .Include(r => r.Cars)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public Task UpdateAsync(Race race)
    {
        throw new NotImplementedException();
    }
}