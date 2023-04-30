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
    public class DoctorProfile: Profile
    {
        public DoctorProfile() {
            CreateMap<Doctor, DoctorDto>();
            CreateMap<DoctorDto, Doctor>();
            CreateMap<Doctor, DoctorUpsertDto>();
            CreateMap<DoctorUpsertDto, Doctor>();
        }
    }
}
