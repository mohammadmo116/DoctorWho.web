using AutoMapper;
using DoctorWho.Db.DTOs;
using DoctorWho.Db.Models;
using DoctorWho.Db.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Repositories
{
    public class AuthorsRepository : IAuthorsRepository
    {

        private DoctorWhoCoreDbContext _context;

        public AuthorsRepository(DoctorWhoCoreDbContext context, IMapper mapper)
        {
            _context = context;
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
        public async Task<bool> UpdateAsync(Author author)
        {
            _context.Authors.Update(author);
            return await _context.SaveChangesAsync() > 0;

        }
        public async Task<bool> RemoveAsync(Author author)
        {
            _context.Authors.Remove(author);
            return await _context.SaveChangesAsync() > 0;



        }

    }
}
