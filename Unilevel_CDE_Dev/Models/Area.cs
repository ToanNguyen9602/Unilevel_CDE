using System;
using System.Collections.Generic;

namespace Unilevel_CDE_Dev.Models
{
    public partial class Area
    {
        public Area()
        {
            Accounts = new HashSet<Account>();
            Distributors = new HashSet<Distributor>();
        }

        public int Id { get; set; }
        public string AreaCode { get; set; } = null!;
        public string Area1 { get; set; } = null!;

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Distributor> Distributors { get; set; }
    }
}
