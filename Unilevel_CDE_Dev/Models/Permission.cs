using System;
using System.Collections.Generic;

namespace Unilevel_CDE_Dev.Models
{
    public partial class Permission
    {
        public Permission()
        {
            Accounts = new HashSet<Account>();
            SurveyRequests = new HashSet<SurveyRequest>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<SurveyRequest> SurveyRequests { get; set; }
    }
}
