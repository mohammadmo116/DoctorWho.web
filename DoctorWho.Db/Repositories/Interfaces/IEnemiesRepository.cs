using DoctorWho.Db.DTOs;
using DoctorWho.Db.Models;

namespace DoctorWho.Db.Repositories.Interfaces
{
    public interface IEnemiesRepository
    {
        bool Create(EnemyDto enemyDto);
        EnemyDto Get(int Id);
        bool Remove(int Id);
        bool Update(int Id, EnemyDto enemyDto);
    }
}