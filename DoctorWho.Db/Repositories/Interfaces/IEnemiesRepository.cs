using DoctorWho.Db.DTOs;
using DoctorWho.Db.Models;

namespace DoctorWho.Db.Repositories.Interfaces
{
    public interface IEnemiesRepository
    {
        Task<bool> CreateAsync(Enemy enemy);
        Task<Enemy> GetAsync(int Id);
        Task<bool> RemoveAsync(int Id);
        Task<bool> UpdateAsync(int Id, Enemy enemy);
    }
}