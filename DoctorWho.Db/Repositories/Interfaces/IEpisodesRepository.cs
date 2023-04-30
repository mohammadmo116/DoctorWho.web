using DoctorWho.Db.DTOs;
using DoctorWho.Db.Models;

namespace DoctorWho.Db.Repositories.Interfaces
{
    public interface IEpisodesRepository
    {
        Task<List<Episode>> GetEpisodesAsync();
        Task<Episode> GetEpisodeAsync(int Id);
        void AddCompanionToEpisode(Episode episode, IEnumerable<Companion> companions);
        void AddEnemyToEpisode(Episode episode, IEnumerable<Enemy> enemies);
        bool AddExistentCompanionToEpisode(List<CompanionEpisode> companionEpisodes);
        bool AddExistnetEnemyToEpisode(List<EnemyEpisode> enemyEpisodes);
        Task AddAsync(Episode episode);
        bool Remove(int Id);
        bool Update(int Id, EpisodeDto episodeDto);
        Task<bool> SaveChangesAsync();
    }
}