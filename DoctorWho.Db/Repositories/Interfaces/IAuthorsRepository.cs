
using DoctorWho.Db.Models;

namespace DoctorWho.Db.Repositories.Interfaces
{
    public interface IAuthorsRepository
    {
        Task<Author> GetAuthorAsync(int Id);
        Task<bool> CreateAsync(Author author);
        Task<bool> RemoveAsync(int Id);
        Task<bool> UpdateAsync(int Id, Author author);
        Task<bool> SaveChangesAsync();
    }
}