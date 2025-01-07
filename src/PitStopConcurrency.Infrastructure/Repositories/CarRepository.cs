using Microsoft.EntityFrameworkCore;
using PitStopConcurrency.Domain.Entities;
using PitStopConcurrency.Domain.Interfaces;
using PitStopConcurrency.Infrastructure.Persistence;

namespace PitStopConcurrency.Infrastructure.Repositories;

public class CarRepository : ICarRepository
{
    private readonly PitStopDbContext _dbContext;

    public CarRepository(PitStopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Car?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Cars
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<Car>> GetAllAsync()
    {
        return await _dbContext.Cars
            .ToListAsync();
    }

    public async Task AddAsync(Car car)
    {
        await _dbContext.Cars.AddAsync(car);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Car car)
    {
        // Delete dinâmico
        _dbContext.Cars.Update(car);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var car = await _dbContext.Cars.FindAsync(id);
        if (car != null)
        {
            _dbContext.Cars.Remove(car);
            await _dbContext.SaveChangesAsync();
        }
    }
}
