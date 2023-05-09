
using DoctorWho.Db.Models;

namespace DoctorWho.Db.Repositories.Interfaces
{
    public interface IAuthorsRepository
    {
        Task<bool> CreateAsync(Author author);
        Task<Author> GetAuthorAsync(int Id);
        Task<bool> RemoveAsync(Author author);
        Task<bool> UpdateAsync(Author author);
    }
}