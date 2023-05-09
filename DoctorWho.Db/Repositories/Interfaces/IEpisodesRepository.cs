using DoctorWho.Db.DTOs;
using DoctorWho.Db.Models;

namespace DoctorWho.Db.Repositories.Interfaces
{
    public interface IEpisodesRepository
    {
        Task<bool> AddAsync(Episode episode);
        Task<bool> AddCompanionToEpisodeAsync(Episode episode, IEnumerable<Companion> companions);
        Task<bool> AddEnemyToEpisodeAsync(Episode episode, IEnumerable<Enemy> enemies);
        Task<bool> AddExistentCompanionToEpisodeAsync(List<CompanionEpisode> companionEpisodes);
        Task<bool> AddExistnetEnemyToEpisodeAsync(List<EnemyEpisode> enemyEpisodes);
        Task<Episode> GetEpisodeAsync(int Id);
        Task<List<Episode>> GetEpisodesAsync();
        Task<bool> RemoveAsync(int Id);
        Task<bool> UpdateAsync(int Id, Episode episode);
    }
}