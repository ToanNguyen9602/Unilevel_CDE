using System;
using System.Collections.Generic;

namespace Unilevel_CDE_Dev.Models
{
    public partial class VisitPlan
    {
        public int Id { get; set; }
        public short? Time { get; set; }
        public DateTime? DateTime { get; set; }
        public short? Status { get; set; }
        public int DistributorId { get; set; }
        public int Requester { get; set; }
        public int? Approver { get; set; }

        public virtual Account? ApproverNavigation { get; set; }
        public virtual Distributor Distributor { get; set; } = null!;
        public virtual Account RequesterNavigation { get; set; } = null!;
    }
}
