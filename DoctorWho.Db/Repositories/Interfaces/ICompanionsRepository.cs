using DoctorWho.Db.DTOs;
using DoctorWho.Db.Models;

namespace DoctorWho.Db.Repositories.Interfaces
{
    public interface ICompanionsRepository
    {
        Task<bool> CreateAsync(Companion companion);
        Task<Companion> GetAsync(int Id);
        Task<bool> RemoveAsync(int Id);
        Task<bool> UpdateAsync(int Id, Companion companion);
    }
}