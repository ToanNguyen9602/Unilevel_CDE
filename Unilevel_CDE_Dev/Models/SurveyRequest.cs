using System;
using System.Collections.Generic;

namespace Unilevel_CDE_Dev.Models
{
    public partial class SurveyRequest
    {
        public SurveyRequest()
        {
            Permissions = new HashSet<Permission>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public bool? Status { get; set; }
        public int? SurveyId { get; set; }
        public int? Receiver { get; set; }

        public virtual Account? ReceiverNavigation { get; set; }
        public virtual Survey? Survey { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
