﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.DTOs
{
    public class EpisodeUpsertDto
    {
       
        public string? SeriesNumber { get; set; }
        public int? EpisodNumber { get; set; }
        public string? EpisodType { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        public DateTime? EpisodDate { get; set; }
        public string? Notes { get; set; }
        public int DoctorId { get; set; }
        public int AuthorId { get; set; }
    }
}
