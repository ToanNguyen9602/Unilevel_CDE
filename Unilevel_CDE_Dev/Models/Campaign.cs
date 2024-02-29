using System;
using System.Collections.Generic;

namespace Unilevel_CDE_Dev.Models
{
    public partial class Campaign
    {
        public Campaign()
        {
            Accounts = new HashSet<Account>();
            Surveys = new HashSet<Survey>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Survey> Surveys { get; set; }
    }
}
