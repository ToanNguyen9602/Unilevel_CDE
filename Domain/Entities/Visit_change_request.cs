using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Visit_change_request")]
    public class VisitChangeRequest
    {
        [Key]
        public int Id { get; set; }

        public int ChangeType { get; set; }

        public DateTime DateStartOld { get; set; }

        public DateTime DateEndOld { get; set; }

        public DateTime DateStartNew { get; set; }

        public DateTime DateEndNew { get; set; }

        public bool Status { get; set; }

        public int RequesterId { get; set; }

        [ForeignKey("RequesterId")]
        public Account Requester { get; set; }

        public int ApproverId { get; set; }

        [ForeignKey("ApproverId")]
        public Account Approver { get; set; }

        public int VisitId { get; set; }

        [ForeignKey("VisitId")]
        public Visit Visit { get; set; }
    }
}
