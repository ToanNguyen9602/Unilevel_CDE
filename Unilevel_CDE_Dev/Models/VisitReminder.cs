using System;
using System.Collections.Generic;

namespace Unilevel_CDE_Dev.Models
{
    public partial class VisitReminder
    {
        public int Id { get; set; }
        public short? ReminderTime { get; set; }
        public DateTime? DateTime { get; set; }
        public int VisitId { get; set; }

        public virtual Visit Visit { get; set; } = null!;
    }
}
