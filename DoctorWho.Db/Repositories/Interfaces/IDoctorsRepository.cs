
using DoctorWho.Db.Models;

namespace DoctorWho.Db.Repositories.Interfaces
{
    public interface IDoctorsRepository
    {
        Task CreateAsyn(Doctor Doctor);
        Task<Doctor> GetDoctorAsync(int Id);
        Task<List<Doctor>> GetAllDoctorsAsync();
        Task RemoveAsync(Doctor Doctor);
        Task UpdateAsync(Doctor Doctor);
        Task<bool> SaveChangesAsync();
    }
}