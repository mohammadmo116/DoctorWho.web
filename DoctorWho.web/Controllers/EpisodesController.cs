using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoctorWho.Db;
using DoctorWho.Db.Models;
using DoctorWho.Db.Repositories.Interfaces;
using AutoMapper;
using DoctorWho.Db.DTOs;
using System.Numerics;

namespace DoctorWho.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EpisodesController : ControllerBase
    {
        private readonly DoctorWhoCoreDbContext _context;
        private readonly IMapper _mapper;
        private readonly IEpisodesRepository _episodes;
        public EpisodesController(DoctorWhoCoreDbContext context,
                                   IMapper mapper,
                                   IEpisodesRepository episodes
                                    )
        {
            _context = context;
            _mapper = mapper;
            _episodes= episodes;
        }

        // GET: api/Episodes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EpisodeDto>>> GetEpisodes()
        {

            var episodes = await _episodes.GetEpisodesAsync();
            if (episodes == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<EpisodeDto>>(episodes));
        }

        // GET: api/Episodes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EpisodeDto>> GetEpisode(int id)
        {
          
            var episode = await _episodes.GetEpisodeAsync(id);

            if (episode == null)
            {
                return NotFound();
            }
            
            return Ok(_mapper.Map<EpisodeDto>(episode));

        }

        // POST: api/Episodes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Episode>> PostEpisode(EpisodeUpsertDto episodeDto)
        {
          if (_context.Episodes == null)
          {
              return Problem("Entity set 'DoctorWhoCoreDbContext.Episodes'  is null.");
          }
            var episode =_mapper.Map<Episode>(episodeDto);
            await _episodes.AddAsync(episode);

            return CreatedAtAction("GetEpisode", new { id = episode.EpisodeId }, episode);
        }
        // POST: api/Episodes/5/Add-Enemy-To-Episode
        [HttpPost("{EpisodeId}/Add-Enemy-To-Episode")]
        public async Task<ActionResult> AddEnemyToEpisode(int EpisodeId, List<EnemyUpsertDto> enemiesDto)
        {
           
            var episode = await _episodes.GetEpisodeAsync(EpisodeId);

            if (episode == null)
            {
                return NotFound("Episode is not existed");
            }
            var enemies = _mapper.Map<IEnumerable<Enemy>>(enemiesDto);
            await _episodes.AddEnemyToEpisodeAsync(episode, enemies);
          
            return NoContent();
        }
        // POST: api/Episodes/5/Add-Companion-To-Episode
        [HttpPost("{EpisodeId}/Add-Companion-To-Episode")]
        public async Task<ActionResult> AddCompanionToEpisode(int EpisodeId, List<CompanionUpsertDto> companionsDto)
        {
            if (_context.Episodes == null)
            {
                return Problem("Entity set 'DoctorWhoCoreDbContext.Episodes'  is null.");
            }
            var episode = await _episodes.GetEpisodeAsync(EpisodeId);

            if (episode == null)
            {
                return NotFound("Episode is not existed");
            }
            var companions = _mapper.Map<IEnumerable<Companion>>(companionsDto);
            await _episodes.AddCompanionToEpisodeAsync(episode, companions);
     

            return NoContent();
        }


    }
}
