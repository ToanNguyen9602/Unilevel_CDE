using System;
using System.Collections.Generic;

namespace Unilevel_CDE_Dev.Models
{
    public partial class Account
    {
        public Account()
        {
            Cms = new HashSet<Cm>();
            Rates = new HashSet<Rate>();
            SurveyRequests = new HashSet<SurveyRequest>();
            SurveyResponses = new HashSet<SurveyResponse>();
            TaskImplementNavigations = new HashSet<Task>();
            TaskReportNavigations = new HashSet<Task>();
            VisitChangeRequestApproverNavigations = new HashSet<VisitChangeRequest>();
            VisitChangeRequestRequesterNavigations = new HashSet<VisitChangeRequest>();
            VisitCreatorNavigations = new HashSet<Visit>();
            VisitGuestNavigations = new HashSet<Visit>();
            VisitPlanApproverNavigations = new HashSet<VisitPlan>();
            VisitPlanRequesterNavigations = new HashSet<VisitPlan>();
            VisitRequestRequesterNavigations = new HashSet<VisitRequest>();
            VisitRequestVisitors = new HashSet<VisitRequest>();
            Campaigns = new HashSet<Campaign>();
            Notifications = new HashSet<Notification>();
            Permissions = new HashSet<Permission>();
            Surveys = new HashSet<Survey>();
        }

        public int Id { get; set; }
        public string Password { get; set; } = null!;
        public string? Fullname { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Photo { get; set; }
        public string? Description { get; set; }
        public bool? Status { get; set; }
        public DateTime? Created { get; set; }
        public int? AreaId { get; set; }
        public int? PositionGroup { get; set; }

        public virtual Area? Area { get; set; }
        public virtual PositionGroup? PositionGroupNavigation { get; set; }
        public virtual ICollection<Cm> Cms { get; set; }
        public virtual ICollection<Rate> Rates { get; set; }
        public virtual ICollection<SurveyRequest> SurveyRequests { get; set; }
        public virtual ICollection<SurveyResponse> SurveyResponses { get; set; }
        public virtual ICollection<Task> TaskImplementNavigations { get; set; }
        public virtual ICollection<Task> TaskReportNavigations { get; set; }
        public virtual ICollection<VisitChangeRequest> VisitChangeRequestApproverNavigations { get; set; }
        public virtual ICollection<VisitChangeRequest> VisitChangeRequestRequesterNavigations { get; set; }
        public virtual ICollection<Visit> VisitCreatorNavigations { get; set; }
        public virtual ICollection<Visit> VisitGuestNavigations { get; set; }
        public virtual ICollection<VisitPlan> VisitPlanApproverNavigations { get; set; }
        public virtual ICollection<VisitPlan> VisitPlanRequesterNavigations { get; set; }
        public virtual ICollection<VisitRequest> VisitRequestRequesterNavigations { get; set; }
        public virtual ICollection<VisitRequest> VisitRequestVisitors { get; set; }

        public virtual ICollection<Campaign> Campaigns { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }
        public virtual ICollection<Survey> Surveys { get; set; }
    }
}
