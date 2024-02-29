using System;
using System.Collections.Generic;

namespace Unilevel_CDE_Dev.Models
{
    public partial class Question
    {
        public Question()
        {
            Surveys = new HashSet<Survey>();
        }

        public int Id { get; set; }
        public string? Text { get; set; }
        public int SurveyId { get; set; }

        public virtual Survey Survey { get; set; } = null!;

        public virtual ICollection<Survey> Surveys { get; set; }
    }
}
