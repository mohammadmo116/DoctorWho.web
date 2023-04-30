using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Models
{

    
    public class CompanionEpisode
    {
        [ForeignKey(nameof(Companion))]
        public int CompanionId { get; set; }
        [ForeignKey(nameof(Episode))]
        public int EpisodeId { get; set; }
       
    }
}
