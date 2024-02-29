using System;
using System.Collections.Generic;

namespace Unilevel_CDE_Dev.Models
{
    public partial class VisitActivity
    {
        public int Id { get; set; }
        public int VisitId { get; set; }
        public short? ActivityType { get; set; }
        public short? Time { get; set; }
        public DateTime? DateTime { get; set; }
        public string? Note { get; set; }

        public virtual Visit Visit { get; set; } = null!;
    }
}
