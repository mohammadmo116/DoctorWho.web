using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DoctorWho.Db.Models;

namespace DoctorWho.web.Data
{
    public class DoctorWhowebContext : DbContext
    {
        public DoctorWhowebContext (DbContextOptions<DoctorWhowebContext> options)
            : base(options)
        {
        }

        public DbSet<DoctorWho.Db.Models.Author> Author { get; set; } = default!;
    }
}
