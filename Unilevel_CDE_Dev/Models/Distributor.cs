using System;
using System.Collections.Generic;

namespace Unilevel_CDE_Dev.Models
{
    public partial class Distributor
    {
        public Distributor()
        {
            VisitPlans = new HashSet<VisitPlan>();
            Visits = new HashSet<Visit>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int AreaId { get; set; }
        public int PositionGroup { get; set; }

        public virtual Area Area { get; set; } = null!;
        public virtual PositionGroup PositionGroupNavigation { get; set; } = null!;
        public virtual ICollection<VisitPlan> VisitPlans { get; set; }
        public virtual ICollection<Visit> Visits { get; set; }
    }
}
