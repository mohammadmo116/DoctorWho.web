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
    public class AuthorProfile: Profile
    {
        public AuthorProfile() {
            CreateMap<Author, AuthorDto>();
            CreateMap<AuthorDto, Author>();
            CreateMap<Author, AuthorUpsertDto>();
            CreateMap<AuthorUpsertDto, Author>();
        }

    }
}
