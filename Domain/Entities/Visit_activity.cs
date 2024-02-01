using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Visit_activity")]
    public class VisitActivity
    {
        [Key]
        public int Id { get; set; }

        public int VisitId { get; set; }

        public short ActivityType { get; set; }

        public int Time { get; set; }

        public DateTime DateTime { get; set; }

        [Column(TypeName = "nvarchar(1000)")]
        public string Note { get; set; }

        [ForeignKey("VisitId")]
        public Visit Visit { get; set; }
    }
}
