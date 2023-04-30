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
        private readonly IMapper _mapper;

        public DoctorsRepository(DoctorWhoCoreDbContext Context)
        {
            _context = Context;
        }
        public async Task CreateAsyn(Doctor doctor)
        {

            await _context.Doctors.AddAsync(doctor);

        }
        public async Task<Doctor> GetDoctorAsync(int Id)
        {

            return await _context.Doctors.FindAsync(Id);


        }
        public async Task<List<Doctor>> GetAllDoctorsAsync()
        {
           
            return await _context.Doctors.OrderBy(x => x.DoctorName).ToListAsync();
         
        }
      
        public async Task UpdateAsync(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
        }
        public async Task RemoveAsync(Doctor doctor)
        {
            _context.Doctors.Remove(doctor); 
        }
        public async Task<bool> SaveChangesAsync()
        {   
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
