using DoctorWho.Db.DTOs;
using DoctorWho.Db.Models;
using DoctorWho.Db.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Repositories
{
    public class CompanionsRepository : ICompanionsRepository
    {
        private DoctorWhoCoreDbContext _context;
        public CompanionsRepository(DoctorWhoCoreDbContext context)
        {
            _context = context;
        }

        public async Task<Companion> GetAsync(int Id)
        {
            return await _context.Companions.FindAsync(Id);
        }
        public async Task<bool> CreateAsync(Companion companion)
        {

            _context.Companions.AddAsync(companion);
            return await _context.SaveChangesAsync() > 0;

        }
        public async Task<bool> UpdateAsync(int Id, Companion companion)
        {

            _context.Companions.Update(companion);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> RemoveAsync(int Id)
        {
            return await _context.Database.ExecuteSqlInterpolatedAsync($"DELETE From Companions where CompanionId = {Id}") > 0;

        }
    }
}
