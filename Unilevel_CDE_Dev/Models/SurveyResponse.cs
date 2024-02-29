using System;
using System.Collections.Generic;

namespace Unilevel_CDE_Dev.Models
{
    public partial class SurveyResponse
    {
        public SurveyResponse()
        {
            Answers = new HashSet<Answer>();
        }

        public int Id { get; set; }
        public int SurveyId { get; set; }
        public int AccountId { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual Survey Survey { get; set; } = null!;

        public virtual ICollection<Answer> Answers { get; set; }
    }
}
