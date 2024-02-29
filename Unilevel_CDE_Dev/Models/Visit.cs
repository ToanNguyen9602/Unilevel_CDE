using System;
using System.Collections.Generic;

namespace Unilevel_CDE_Dev.Models
{
    public partial class Visit
    {
        public Visit()
        {
            VisitActivities = new HashSet<VisitActivity>();
            VisitChangeRequests = new HashSet<VisitChangeRequest>();
            VisitReminders = new HashSet<VisitReminder>();
        }

        public int Id { get; set; }
        public short? Time { get; set; }
        public DateTime? DateTime { get; set; }
        public string? Intent { get; set; }
        public short? Status { get; set; }
        public int Creator { get; set; }
        public int? Guest { get; set; }
        public int DistributorId { get; set; }
        public int TaskId { get; set; }

        public virtual Account CreatorNavigation { get; set; } = null!;
        public virtual Distributor Distributor { get; set; } = null!;
        public virtual Account? GuestNavigation { get; set; }
        public virtual Task Task { get; set; } = null!;
        public virtual ICollection<VisitActivity> VisitActivities { get; set; }
        public virtual ICollection<VisitChangeRequest> VisitChangeRequests { get; set; }
        public virtual ICollection<VisitReminder> VisitReminders { get; set; }
    }
}
