using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Visit_change_notification")]
    public class VisitChangeNotification
    {
        [Key]
        public int Id { get; set; }

        [StringLength(250)]
        public string Title { get; set; }

        [StringLength(1000)]
        public string Content { get; set; }

        public DateTime Created { get; set; }

        public int VisitChangeRequestId { get; set; }

        [ForeignKey("VisitChangeRequestId")]
        public VisitChangeRequest VisitChangeRequest { get; set; }
    }
}
