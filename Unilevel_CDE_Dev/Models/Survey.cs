using System;
using System.Collections.Generic;

namespace Unilevel_CDE_Dev.Models
{
    public partial class Survey
    {
        public Survey()
        {
            Answers = new HashSet<Answer>();
            Questions = new HashSet<Question>();
            SurveyRequests = new HashSet<SurveyRequest>();
            SurveyResponses = new HashSet<SurveyResponse>();
            Campaigns = new HashSet<Campaign>();
            QuestionsNavigation = new HashSet<Question>();
            Users = new HashSet<Account>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<SurveyRequest> SurveyRequests { get; set; }
        public virtual ICollection<SurveyResponse> SurveyResponses { get; set; }

        public virtual ICollection<Campaign> Campaigns { get; set; }
        public virtual ICollection<Question> QuestionsNavigation { get; set; }
        public virtual ICollection<Account> Users { get; set; }
    }
}
