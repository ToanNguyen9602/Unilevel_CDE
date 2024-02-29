using System;
using System.Collections.Generic;

namespace Unilevel_CDE_Dev.Models
{
    public partial class VisitChangeRequest
    {
        public VisitChangeRequest()
        {
            VisitChangeNotifications = new HashSet<VisitChangeNotification>();
        }

        public int Id { get; set; }
        public short? ChangeType { get; set; }
        public DateTime? DateStartOld { get; set; }
        public DateTime? DateEndOld { get; set; }
        public DateTime? DateStartNew { get; set; }
        public DateTime? DateEndNew { get; set; }
        public bool? Status { get; set; }
        public int Requester { get; set; }
        public int? Approver { get; set; }
        public int VisitId { get; set; }

        public virtual Account? ApproverNavigation { get; set; }
        public virtual Account RequesterNavigation { get; set; } = null!;
        public virtual Visit Visit { get; set; } = null!;
        public virtual ICollection<VisitChangeNotification> VisitChangeNotifications { get; set; }
    }
}
