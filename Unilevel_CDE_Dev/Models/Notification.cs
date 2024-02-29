using System;
using System.Collections.Generic;

namespace Unilevel_CDE_Dev.Models
{
    public partial class Notification
    {
        public Notification()
        {
            staff = new HashSet<Account>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime? Created { get; set; }

        public virtual ICollection<Account> staff { get; set; }
    }
}
