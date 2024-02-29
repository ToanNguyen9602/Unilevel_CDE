using System;
using System.Collections.Generic;

namespace Unilevel_CDE_Dev.Models
{
    public partial class PositionGroup
    {
        public PositionGroup()
        {
            Accounts = new HashSet<Account>();
            Distributors = new HashSet<Distributor>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Distributor> Distributors { get; set; }
    }
}
