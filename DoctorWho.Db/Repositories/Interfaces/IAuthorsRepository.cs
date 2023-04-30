
using DoctorWho.Db.Models;

namespace DoctorWho.Db.Repositories.Interfaces
{
    public interface IAuthorsRepository
    {
        Task<bool> CreateAsync(Author author);
        Task<bool> RemoveAsync(int Id);
        Task<bool> UpdateAsync(int Id, Author author);
    }
}