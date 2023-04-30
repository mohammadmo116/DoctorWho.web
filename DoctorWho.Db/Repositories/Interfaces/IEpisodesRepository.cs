using DoctorWho.Db.DTOs;
using DoctorWho.Db.Models;

namespace DoctorWho.Db.Repositories.Interfaces
{
    public interface IEpisodesRepository
    {
        Task<List<Episode>> GetEpisodesAsync();
        Task<Episode> GetEpisodeAsync(int Id);
        bool AddCompanionToEpisode(int EpisodeId, CompanionDto companionDto);
        bool AddEnemyToEpisode(int EpisodeId, EnemyDto enemyDto);
        bool AddExistentCompanionToEpisode(int EpisodeId, int companionId);
        bool AddExistnetEnemyToEpisode(int EpisodeId, int enemyId);
        Task AddAsync(Episode episode);
        bool Remove(int Id);
        bool Update(int Id, EpisodeDto episodeDto);
        Task<bool> SaveChangesAsync();
    }
}