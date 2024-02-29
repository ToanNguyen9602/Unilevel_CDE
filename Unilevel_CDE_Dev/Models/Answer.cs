using System;
using System.Collections.Generic;

namespace Unilevel_CDE_Dev.Models
{
    public partial class Answer
    {
        public Answer()
        {
            SurveyResponses = new HashSet<SurveyResponse>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? SurveyId { get; set; }

        public virtual Survey? Survey { get; set; }

        public virtual ICollection<SurveyResponse> SurveyResponses { get; set; }
    }
}
