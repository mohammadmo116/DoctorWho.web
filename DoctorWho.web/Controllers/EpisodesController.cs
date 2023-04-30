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
                                   IEpisodesRepository episodes)
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
        public async Task<ActionResult<Episode>> PostEpisode(EpisodeDto episodeDto)
        {
          if (_context.Episodes == null)
          {
              return Problem("Entity set 'DoctorWhoCoreDbContext.Episodes'  is null.");
          }
            var episode =_mapper.Map<Episode>(episodeDto);
            await _episodes.AddAsync(episode);
            await _episodes.SaveChangesAsync();

            return CreatedAtAction("GetEpisode", new { id = episode.EpisodeId }, episode);
        }

      
    }
}
