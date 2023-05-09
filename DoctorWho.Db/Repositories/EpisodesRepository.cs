using DoctorWho.Db.DbFunctions;
using DoctorWho.Db.DTOs;
using DoctorWho.Db.Models;
using DoctorWho.Db.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Repositories
{
    public class EpisodesRepository : IEpisodesRepository
    {
        private DoctorWhoCoreDbContext _context;
        public EpisodesRepository(DoctorWhoCoreDbContext Context)
        {
            _context = Context;
        }
        public async Task<List<Episode>> GetEpisodesAsync()
        {

            return await _context.Episodes.OrderBy(x => x.EpisodDate).ToListAsync();

        }
        public async Task<Episode> GetEpisodeAsync(int Id)
        {
            return await _context.Episodes.FindAsync(Id);

        }
        public async Task<bool> AddAsync(Episode episode)
        {

            await _context.Episodes.AddAsync(episode);
            return await _context.SaveChangesAsync() > 0;

        }
        public async Task<bool> UpdateAsync(int Id, Episode episode)
        {
            _context.Episodes.Update(episode);
            return await _context.SaveChangesAsync() > 0;

        }
        public async Task<bool> RemoveAsync(int Id)
        {
            return await _context.Database.ExecuteSqlInterpolatedAsync($"DELETE From Episodes where EpisodeId = {Id}") > 0;

        }
        public async Task<bool> AddEnemyToEpisodeAsync(Episode episode, IEnumerable<Enemy> enemies)
        {
            episode.Enemies.AddRange(enemies);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> AddExistnetEnemyToEpisodeAsync(List<EnemyEpisode> enemyEpisodes)
        {
            await _context.AddRangeAsync(enemyEpisodes);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> AddCompanionToEpisodeAsync(Episode episode, IEnumerable<Companion> companions)
        {
            episode.Companions.AddRange(companions);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> AddExistentCompanionToEpisodeAsync(List<CompanionEpisode> companionEpisodes)
        {
            await _context.AddRangeAsync(companionEpisodes);
            return await _context.SaveChangesAsync() > 0;

        }

    }

}
