using System;
using System.Collections.Generic;

namespace Unilevel_CDE_Dev.Models
{
    public partial class Cm
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Photo { get; set; }
        public string? Link { get; set; }
        public DateTime? Created { get; set; }
        public bool? Status { get; set; }
        public int? Creator { get; set; }

        public virtual Account? CreatorNavigation { get; set; }
    }
}
