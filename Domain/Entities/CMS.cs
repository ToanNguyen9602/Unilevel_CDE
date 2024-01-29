using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("CMS")]
    public class CMS
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string Description { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string Photo { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string Link { get; set; }

        public DateTime Created { get; set; }

        public bool Status { get; set; }

        public int Creator { get; set; }

        [ForeignKey("Creator")]
        public Account CreatorAccount { get; set; }
    }
}
