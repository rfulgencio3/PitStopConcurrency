using PitStopConcurrency.Domain.Entities;

namespace PitStopConcurrency.Domain.Interfaces;

public interface IRaceRepository
{
    Task<Race?> GetByIdAsync(Guid id);
    Task<List<Race>> GetAllAsync();
    Task AddAsync(Race race);
    Task UpdateAsync(Race race);
    Task DeleteAsync(Guid id);
}
