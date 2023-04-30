using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Models
{
    public class Author
    {
        public Author() {
            Episodes = new List<Episode>();
        }
        public int AuthorId { get; set; }
        [Required]
        public string AuthorName { get; set; } = string.Empty;

        public List<Episode>? Episodes { get; set; }

    }
}
