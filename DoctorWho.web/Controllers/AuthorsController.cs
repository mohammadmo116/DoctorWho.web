using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoctorWho.Db.Models;
using DoctorWho.Db.DTOs;
using DoctorWho.Db.Repositories.Interfaces;
using AutoMapper;

namespace DoctorWho.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAuthorsRepository _authors;

        public AuthorsController(
                                 IMapper mapper,
                                 IAuthorsRepository authors)
        {
            _mapper = mapper;
            _authors = authors;
        }

  
        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> GetAuthor(int id)
        {

            var author = await _authors.GetAuthorAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<AuthorDto>(author));
        }

        // PUT: api/Authors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(int id, AuthorUpsertDto authorDto)
        {
            var author = await _authors.GetAuthorAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            _mapper.Map(authorDto, author);
            await _authors.UpdateAsync(author);


            return NoContent();
        }

       


    }
}
