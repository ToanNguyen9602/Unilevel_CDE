using System;
using System.Collections.Generic;

namespace Unilevel_CDE_Dev.Models
{
    public partial class Task
    {
        public Task()
        {
            Rates = new HashSet<Rate>();
            Visits = new HashSet<Visit>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public string? File { get; set; }
        public string? Description { get; set; }
        public short? Status { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public int Report { get; set; }
        public int Implement { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category? Category { get; set; }
        public virtual Account ImplementNavigation { get; set; } = null!;
        public virtual Account ReportNavigation { get; set; } = null!;
        public virtual ICollection<Rate> Rates { get; set; }
        public virtual ICollection<Visit> Visits { get; set; }
    }
}
