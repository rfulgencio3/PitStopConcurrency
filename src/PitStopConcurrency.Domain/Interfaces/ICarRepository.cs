using PitStopConcurrency.Domain.Entities;

namespace PitStopConcurrency.Domain.Interfaces;

public interface ICarRepository
{
    Task<Car?> GetByIdAsync(Guid id);
    Task<List<Car>> GetAllAsync();
    Task AddAsync(Car car);
    Task UpdateAsync(Car car);
    Task DeleteAsync(Guid id);
}
