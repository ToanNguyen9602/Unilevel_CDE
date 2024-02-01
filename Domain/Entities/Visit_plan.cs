using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{

    [Table("Visit_plan")]
    public class VisitPlan
    {
        [Key]
        public int Id { get; set; }

        public int Time { get; set; }

        public DateTime DateTime { get; set; }

        public short Status { get; set; }

        public int DistributorId { get; set; }

        public int RequesterId { get; set; }

        public int? ApproverId { get; set; }

        [ForeignKey("DistributorId")]
        public Distributor Distributor { get; set; }

        [ForeignKey("RequesterId")]
        public Account RequesterAccount { get; set; }

        [ForeignKey("ApproverId")]
        public Account ApproverAccount { get; set; }
    }
}
