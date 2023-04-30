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
        public void AddEnemyToEpisode(Episode episode, IEnumerable<Enemy> enemies)
        {       
            episode.Enemies.AddRange(enemies);   
        }
        public bool AddExistnetEnemyToEpisode(List<EnemyEpisode> enemyEpisodes)
        {
            _context.AddRange(enemyEpisodes);
            var NumerOfRowsEffected = _context.SaveChanges();
            return NumerOfRowsEffected > 0;
        }
        public void AddCompanionToEpisode(Episode episode, IEnumerable<Companion> companions)
        {
            episode.Companions.AddRange(companions);
        }
        public bool AddExistentCompanionToEpisode(List<CompanionEpisode> companionEpisodes)
        {
            _context.AddRange(companionEpisodes);
            var NumerOfRowsEffected = _context.SaveChanges();
            return NumerOfRowsEffected > 0;
        }
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }

}
