using DoctorWho.Db.DTOs;
using DoctorWho.Db.Models;

namespace DoctorWho.Db.Repositories.Interfaces
{
    public interface ICompanionsRepository
    {
        bool Create(CompanionDto companionDto);
        Companion Get(int Id);
        bool Remove(int Id);
        bool Update(int Id, CompanionDto companionDto);
    }
}