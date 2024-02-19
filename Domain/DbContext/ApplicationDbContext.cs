using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DbContext
{
    public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Area> Areas { get; set; }
        public DbSet<Position_group> Positions { get; set; }
        public DbSet<User_list> Users { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Distributor> Distributors { get; set; }
        /*public DbSet<Entities.Task> Tasks { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Notifi_user> Notifi_Users { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Survey_detail> survey_Details { get; set; }
        public DbSet<Survey_request> survey_Requests { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<CMS> cMs { get; set; }
        public DbSet<Visit> visits { get; set; }
        public DbSet<VisitPlan> visit_Plans { get; set; }
        public DbSet<VisitActivity> visit_Activities { get; set; }
        public DbSet<VisitRequest> visit_Requests { get; set; }
        public DbSet<VisitReminder> visitReminders { get; set; }
        public DbSet<VisitChangeRequest> visitChangeRequests { get; set; }
        public DbSet<VisitChangeNotification> visitChangeNotifications { get; set; }
        public DbSet<Question> question { get; set; }
        public DbSet<Campaign> campaigns { get; set; }
        public DbSet<CampaignUser> campaignUsers { get; set; }
        public DbSet<Permission> permissions { get; set; }
        public DbSet<User_permission> userPermissions { get; set; }
        public DbSet<Survey_request_Permission> survey_Request_Permissions { get; set; }
        public DbSet<Survey_response> survey_Responses { get; set; }
        public DbSet<Survey_question> survey_Questions { get; set; }
        public DbSet<Survey_response_answer> survey_Response_Answers { get; set; }
        public DbSet<Survey_campaign> survey_Campaigns { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CampaignUser>()
                .HasKey(cu => new { cu.Campaign_id, cu.Account_id });

            modelBuilder.Entity<Notifi_user>()
                .HasKey(nu => new { nu.Notification_id, nu.Staff });

            modelBuilder.Entity<Survey_request_Permission>()
                .HasKey(sr => new { sr.Survey_request_id, sr.Permission_id });

            modelBuilder.Entity<Survey_request_Permission>()
                .HasOne(sr => sr.Survey_request)
                .WithMany()
                .HasForeignKey(sr => sr.Survey_request_id);

            modelBuilder.Entity<Survey_request_Permission>()
                .HasOne(sr => sr.Permission)
                .WithMany()
                .HasForeignKey(sr => sr.Permission_id);
            modelBuilder.Entity<User_permission>()
       .HasKey(up => new { up.Account_id, up.Permission_id });

            modelBuilder.Entity<User_permission>()
                .HasOne(up => up.Account)
                .WithMany()
                .HasForeignKey(up => up.Account_id);

            modelBuilder.Entity<User_permission>()
                .HasOne(up => up.Permission)
                .WithMany()
                .HasForeignKey(up => up.Permission_id);
        }*/

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
    }
}
