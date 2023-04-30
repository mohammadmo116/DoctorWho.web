using AutoMapper;
using DoctorWho.Db.DTOs;
using DoctorWho.Db.Models;
using DoctorWho.Db.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Repositories
{
    public class AuthorsRepository : IAuthorsRepository
    {

        private DoctorWhoCoreDbContext _context;
        private readonly IMapper _mapper;

        public AuthorsRepository(DoctorWhoCoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Author> GetAuthorAsync(int Id)
        {

            return await _context.Authors.FindAsync(Id);

        }
        public async Task<bool> CreateAsync(Author author)
        {

            _context.Authors.Add(author);
            return await _context.SaveChangesAsync() > 0;

        }
        public async Task<bool> UpdateAsync(int Id, Author author)
        {
            var temp = await _context.Authors.FindAsync(Id) ?? throw new Exception("404 DoctorNotFound");
            _context.Entry(author).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0; ;

        }
        public async Task<bool> RemoveAsync(int Id)
        {
            Author author = await _context.Authors.FindAsync(Id) ?? throw new Exception("404 DoctorNotFound");
            _context.Authors.Remove(author);
            return await _context.SaveChangesAsync() > 0;


        }
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
