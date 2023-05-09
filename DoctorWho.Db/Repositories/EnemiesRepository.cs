using AutoMapper;
using DoctorWho.Db.DTOs;
using DoctorWho.Db.Models;
using DoctorWho.Db.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Repositories
{
    public class EnemiesRepository : IEnemiesRepository
    {
        private DoctorWhoCoreDbContext _context;

        public EnemiesRepository(DoctorWhoCoreDbContext context, IMapper mapper)
        {
            _context = context;
        }
        public async Task<Enemy> GetAsync(int Id)
        {

            return await _context.Enemies.FindAsync(Id);
        }

        public async Task<bool> CreateAsync(Enemy enemy)
        {
            await _context.Enemies.AddAsync(enemy);
            return await _context.SaveChangesAsync() > 0;

        }
        public async Task<bool> UpdateAsync(int Id, Enemy enemy)
        {
            _context.Enemies.Update(enemy);
            return await _context.SaveChangesAsync() > 0;

        }
        public async Task<bool> RemoveAsync(int Id)
        {

            return await _context.Database.ExecuteSqlInterpolatedAsync($"DELETE From Enemies where EnemyId = {Id}") > 0;

        }
    }
}
