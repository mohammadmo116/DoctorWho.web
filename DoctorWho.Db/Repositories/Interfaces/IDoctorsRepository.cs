
using DoctorWho.Db.Models;
using System.Threading.Tasks;

namespace DoctorWho.Db.Repositories.Interfaces
{
    public interface IDoctorsRepository
    {
        Task<bool> CreateAsyn(Doctor Doctor);
        Task<Doctor> GetDoctorAsync(int Id);
        Task<List<Doctor>> GetAllDoctorsAsync();
        Task<bool> RemoveAsync(Doctor Doctor);
        Task<bool> UpdateAsync(Doctor Doctor);
     
    }
}