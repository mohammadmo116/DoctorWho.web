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
    public class EpisodeProfile: Profile
    {
        public EpisodeProfile() {
            CreateMap<Episode, EpisodeDto>();
            CreateMap<EpisodeDto, Episode>();

        }
    }
}
