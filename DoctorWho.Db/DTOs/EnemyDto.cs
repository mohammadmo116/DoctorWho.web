using DoctorWho.Db.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.DTOs
{
    public class EnemyDto : EnemyUpsertDto
    {

        public int EnemyId { get; set; }
 
      
    }
}
