using AutoMapper;
using DoctorWho.Db.DTOs;
using DoctorWho.Db.Models;
using DoctorWho.Db.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Repositories
{
    public class DoctorsRepository : IDoctorsRepository
    {

        private DoctorWhoCoreDbContext _context;

        public DoctorsRepository(DoctorWhoCoreDbContext Context)
        {
            _context = Context;
        }
        public async Task<bool> CreateAsyn(Doctor doctor)
        {

            await _context.Doctors.AddAsync(doctor);
            return await _context.SaveChangesAsync() > 0;

        }
        public async Task<Doctor> GetDoctorAsync(int Id)
        {

            return await _context.Doctors.FindAsync(Id);


        }
        public async Task<List<Doctor>> GetAllDoctorsAsync()
        {
           
            return await _context.Doctors.OrderBy(x => x.DoctorName).ToListAsync();
         
        }
      
        public async Task<bool> UpdateAsync(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> RemoveAsync(Doctor doctor)
        {
            _context.Doctors.Remove(doctor);
            return await _context.SaveChangesAsync() > 0;
        }
       

    }
}
