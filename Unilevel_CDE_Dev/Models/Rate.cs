using System;
using System.Collections.Generic;

namespace Unilevel_CDE_Dev.Models
{
    public partial class Rate
    {
        public int Id { get; set; }
        public short? Rate1 { get; set; }
        public string? Comment { get; set; }
        public DateTime? Created { get; set; }
        public int Rater { get; set; }
        public int TaskId { get; set; }

        public virtual Account RaterNavigation { get; set; } = null!;
        public virtual Task Task { get; set; } = null!;
    }
}
