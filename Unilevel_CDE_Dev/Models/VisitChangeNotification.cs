using System;
using System.Collections.Generic;

namespace Unilevel_CDE_Dev.Models
{
    public partial class VisitChangeNotification
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime? Created { get; set; }
        public int VisitChangeRequestId { get; set; }

        public virtual VisitChangeRequest VisitChangeRequest { get; set; } = null!;
    }
}
