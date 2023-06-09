﻿
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Models
{
    public class Episode
    {
        public Episode() {
            
            Doctor = new Doctor();
            Author = new Author();
            Companions = new List<Companion>();
            Enemies = new List<Enemy>();
         
        }
        public int EpisodeId { get; set; }
        [MaxLength(12)]
        public string? SeriesNumber { get; set; }
        public int? EpisodNumber { get; set; }
        public string? EpisodType { get; set; }
        [Required]
        public string Title { get; set; }=string.Empty;
        public DateTime? EpisodDate { get; set; }
        public string? Notes { get; set; }
        public Doctor? Doctor { get; set; }
        public int? DoctorId { get; set; }
        public Author? Author { get; set; }
        public int? AuthorId { get; set; }
        public List<Enemy>? Enemies { get; set; }
        public List<Companion>? Companions { get; set; }

    }
}
