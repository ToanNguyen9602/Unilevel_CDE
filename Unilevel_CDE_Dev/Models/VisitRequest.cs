using System;
using System.Collections.Generic;

namespace Unilevel_CDE_Dev.Models
{
    public partial class VisitRequest
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public bool? Status { get; set; }
        public int? VisitorId { get; set; }
        public int Requester { get; set; }

        public virtual Account RequesterNavigation { get; set; } = null!;
        public virtual Account? Visitor { get; set; }
    }
}
