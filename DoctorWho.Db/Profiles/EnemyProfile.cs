using AutoMapper;
using DoctorWho.Db.DTOs;
using DoctorWho.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Profiles
{
    public class EnemyProfile: Profile
    {
        public EnemyProfile() {
            CreateMap<Enemy, EnemyDto>();
            CreateMap<EnemyDto, Enemy>();
            CreateMap<Enemy, EnemyUpsertDto>();
            CreateMap<EnemyUpsertDto, Enemy>();
        }
    }
}
