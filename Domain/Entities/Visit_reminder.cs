using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Visit_reminder")]
    public class VisitReminder
    {
        [Key]
        public int Id { get; set; }

        public int ReminderTime { get; set; }

        public DateTime DateTime { get; set; }

        public int VisitId { get; set; }

        [ForeignKey("VisitId")]
        public Visit Visit { get; set; }
    }
}
