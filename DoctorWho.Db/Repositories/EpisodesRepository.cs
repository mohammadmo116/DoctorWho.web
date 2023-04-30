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
        public async Task AddAsync(Episode episode)
        {
            
            await _context.Episodes.AddAsync(episode);
        
        }
        public bool Update(int Id, EpisodeDto episodeDto)
        {
            Episode episode = _context.Episodes.FirstOrDefault(x => x.EpisodeId == Id) ?? throw new Exception("404 DoctorNotFound");
            episode.SeriesNumber = episodeDto.SeriesNumber;
            episode.EpisodNumber = episodeDto.EpisodNumber;
            episode.EpisodType = episodeDto.EpisodType;
            episode.Title = episodeDto.Title;
            episode.EpisodDate = episodeDto.EpisodDate;
            episode.Notes = episodeDto.Notes;
            episode.DoctorId = episodeDto.DoctorId;
            episode.AuthorId = episodeDto.AuthorId;
            _context.Episodes.Update(episode);
            var NumerOfRowsEffected = _context.SaveChanges();
            return NumerOfRowsEffected > 0;
        }
        public bool Remove(int Id)
        {
            var NumerOfRowsEffected = _context.Database.ExecuteSqlInterpolated($"DELETE From Episodes where EpisodeId = {Id}");
            return NumerOfRowsEffected > 0;
        }
        public bool AddEnemyToEpisode(int EpisodeId, EnemyDto enemyDto)
        {
            Episode episode = _context.Episodes.FirstOrDefault(x => x.EpisodeId == EpisodeId) ?? throw new Exception("404 DoctorNotFound");
            List<Enemy> enemies = new List<Enemy> {
                new() {
                        EnemyName = enemyDto.EnemyName,
                        Description = enemyDto.Description
                      }
            };

            episode.Enemies.AddRange(enemies);
            var NumerOfRowsEffected = _context.SaveChanges();
            return NumerOfRowsEffected > 0;
        }
        public bool AddExistnetEnemyToEpisode(int EpisodeId, int enemyId)
        {
            _context.AddRange(
                new EnemyEpisode()
                {
                    EnemyId = enemyId,
                    EpisodeId = EpisodeId
                }
                );
            var NumerOfRowsEffected = _context.SaveChanges();
            return NumerOfRowsEffected > 0;
        }
        public bool AddCompanionToEpisode(int EpisodeId, CompanionDto companionDto)
        {
            Episode episode = _context.Episodes.FirstOrDefault(x => x.EpisodeId == EpisodeId) ?? throw new Exception("404 DoctorNotFound");
            List<Companion> companions = new List<Companion> {
                new() {
                        CompanionName = companionDto.CompanionName,
                        WhoPlayed = companionDto.WhoPlayed
                      }
            };

            episode.Companions.AddRange(companions);
            var NumerOfRowsEffected = _context.SaveChanges();
            return NumerOfRowsEffected > 0;
        }
        public bool AddExistentCompanionToEpisode(int EpisodeId, int companionId)
        {
            _context.AddRange(
                 new CompanionEpisode()
                 {
                     CompanionId = companionId,
                     EpisodeId = EpisodeId
                 }
                 );
            var NumerOfRowsEffected = _context.SaveChanges();
            return NumerOfRowsEffected > 0;
        }
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }

}
