using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Unilevel_CDE_Dev.Models
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Answer> Answers { get; set; } = null!;
        public virtual DbSet<Area> Areas { get; set; } = null!;
        public virtual DbSet<Campaign> Campaigns { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Cm> Cms { get; set; } = null!;
        public virtual DbSet<Distributor> Distributors { get; set; } = null!;
        public virtual DbSet<Medium> Media { get; set; } = null!;
        public virtual DbSet<Notification> Notifications { get; set; } = null!;
        public virtual DbSet<Permission> Permissions { get; set; } = null!;
        public virtual DbSet<PositionGroup> PositionGroups { get; set; } = null!;
        public virtual DbSet<Question> Questions { get; set; } = null!;
        public virtual DbSet<Rate> Rates { get; set; } = null!;
        public virtual DbSet<Survey> Surveys { get; set; } = null!;
        public virtual DbSet<SurveyRequest> SurveyRequests { get; set; } = null!;
        public virtual DbSet<SurveyResponse> SurveyResponses { get; set; } = null!;
        public virtual DbSet<Task> Tasks { get; set; } = null!;
        public virtual DbSet<UserList> UserLists { get; set; } = null!;
        public virtual DbSet<Visit> Visits { get; set; } = null!;
        public virtual DbSet<VisitActivity> VisitActivities { get; set; } = null!;
        public virtual DbSet<VisitChangeNotification> VisitChangeNotifications { get; set; } = null!;
        public virtual DbSet<VisitChangeRequest> VisitChangeRequests { get; set; } = null!;
        public virtual DbSet<VisitPlan> VisitPlans { get; set; } = null!;
        public virtual DbSet<VisitReminder> VisitReminders { get; set; } = null!;
        public virtual DbSet<VisitRequest> VisitRequests { get; set; } = null!;

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=MSI\\TOANNGUYEN;Database=Unilevel_CDE;user id=sa;password=123456;trusted_connection=true;encrypt=false");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.AreaId).HasColumnName("Area_id");

                entity.Property(e => e.Created).HasColumnType("date");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Fullname).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(150);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.Photo).HasMaxLength(250);

                entity.Property(e => e.PositionGroup).HasColumnName("Position_group");

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.AreaId)
                    .HasConstraintName("FK__Account__Area_id__2E1BDC42");

                entity.HasOne(d => d.PositionGroupNavigation)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.PositionGroup)
                    .HasConstraintName("FK__Account__Positio__2F10007B");

                entity.HasMany(d => d.Permissions)
                    .WithMany(p => p.Accounts)
                    .UsingEntity<Dictionary<string, object>>(
                        "UserPermission",
                        l => l.HasOne<Permission>().WithMany().HasForeignKey("PermissionId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__User_perm__Permi__7A672E12"),
                        r => r.HasOne<Account>().WithMany().HasForeignKey("AccountId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__User_perm__Accou__797309D9"),
                        j =>
                        {
                            j.HasKey("AccountId", "PermissionId").HasName("PK__User_per__790604080B46C52F");

                            j.ToTable("User_permission");

                            j.IndexerProperty<int>("AccountId").HasColumnName("Account_id");

                            j.IndexerProperty<int>("PermissionId").HasColumnName("Permission_id");
                        });
            });

            modelBuilder.Entity<Answer>(entity =>
            {
                entity.ToTable("Answer");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.SurveyId).HasColumnName("Survey_id");

                entity.HasOne(d => d.Survey)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.SurveyId)
                    .HasConstraintName("FK__Answer__Survey_i__49C3F6B7");
            });

            modelBuilder.Entity<Area>(entity =>
            {
                entity.ToTable("Area");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Area1)
                    .HasMaxLength(50)
                    .HasColumnName("Area");

                entity.Property(e => e.AreaCode)
                    .HasMaxLength(50)
                    .HasColumnName("Area_code");
            });

            modelBuilder.Entity<Campaign>(entity =>
            {
                entity.ToTable("Campaign");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateEnd)
                    .HasColumnType("date")
                    .HasColumnName("Date_end");

                entity.Property(e => e.DateStart)
                    .HasColumnType("date")
                    .HasColumnName("Date_start");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.HasMany(d => d.Accounts)
                    .WithMany(p => p.Campaigns)
                    .UsingEntity<Dictionary<string, object>>(
                        "CampaignUser",
                        l => l.HasOne<Account>().WithMany().HasForeignKey("AccountId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Campaign___Accou__74AE54BC"),
                        r => r.HasOne<Campaign>().WithMany().HasForeignKey("CampaignId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Campaign___Campa__73BA3083"),
                        j =>
                        {
                            j.HasKey("CampaignId", "AccountId").HasName("PK__Campaign__E8DE9C0B94C45986");

                            j.ToTable("Campaign_user");

                            j.IndexerProperty<int>("CampaignId").HasColumnName("Campaign_id");

                            j.IndexerProperty<int>("AccountId").HasColumnName("Account_id");
                        });
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(250);
            });

            modelBuilder.Entity<Cm>(entity =>
            {
                entity.ToTable("CMS");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Created).HasColumnType("date");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Link).HasMaxLength(250);

                entity.Property(e => e.Photo).HasMaxLength(250);

                entity.Property(e => e.Title).HasMaxLength(250);

                entity.HasOne(d => d.CreatorNavigation)
                    .WithMany(p => p.Cms)
                    .HasForeignKey(d => d.Creator)
                    .HasConstraintName("FK__CMS__Creator__5070F446");
            });

            modelBuilder.Entity<Distributor>(entity =>
            {
                entity.ToTable("Distributor");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(250);

                entity.Property(e => e.AreaId).HasColumnName("Area_id");

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.Phone).HasMaxLength(250);

                entity.Property(e => e.PositionGroup).HasColumnName("Position_group");

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.Distributors)
                    .HasForeignKey(d => d.AreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Distribut__Area___31EC6D26");

                entity.HasOne(d => d.PositionGroupNavigation)
                    .WithMany(p => p.Distributors)
                    .HasForeignKey(d => d.PositionGroup)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Distribut__Posit__32E0915F");
            });

            modelBuilder.Entity<Medium>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.NameFile)
                    .HasMaxLength(250)
                    .HasColumnName("Name_file");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.ToTable("Notification");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Content).HasMaxLength(250);

                entity.Property(e => e.Created).HasColumnType("date");

                entity.Property(e => e.Title).HasMaxLength(250);

                entity.HasMany(d => d.staff)
                    .WithMany(p => p.Notifications)
                    .UsingEntity<Dictionary<string, object>>(
                        "NotifiUser",
                        l => l.HasOne<Account>().WithMany().HasForeignKey("Staff").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Notifi_us__Staff__3D5E1FD2"),
                        r => r.HasOne<Notification>().WithMany().HasForeignKey("NotificationId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Notifi_us__Notif__3C69FB99"),
                        j =>
                        {
                            j.HasKey("NotificationId", "Staff").HasName("PK__Notifi_u__27B8744A21AC37B4");

                            j.ToTable("Notifi_user");

                            j.IndexerProperty<int>("NotificationId").HasColumnName("Notification_id");
                        });
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.ToTable("Permission");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(250);
            });

            modelBuilder.Entity<PositionGroup>(entity =>
            {
                entity.ToTable("Position_group");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(250);
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("Question");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.SurveyId).HasColumnName("Survey_id");

                entity.Property(e => e.Text).HasMaxLength(1000);

                entity.HasOne(d => d.Survey)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.SurveyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Question__Survey__6EF57B66");
            });

            modelBuilder.Entity<Rate>(entity =>
            {
                entity.ToTable("Rate");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Comment).HasMaxLength(250);

                entity.Property(e => e.Created).HasColumnType("date");

                entity.Property(e => e.Rate1).HasColumnName("Rate");

                entity.Property(e => e.TaskId).HasColumnName("Task_id");

                entity.HasOne(d => d.RaterNavigation)
                    .WithMany(p => p.Rates)
                    .HasForeignKey(d => d.Rater)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Rate__Rater__4CA06362");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.Rates)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Rate__Task_id__4D94879B");
            });

            modelBuilder.Entity<Survey>(entity =>
            {
                entity.ToTable("Survey");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.HasMany(d => d.Campaigns)
                    .WithMany(p => p.Surveys)
                    .UsingEntity<Dictionary<string, object>>(
                        "SurveyCampaign",
                        l => l.HasOne<Campaign>().WithMany().HasForeignKey("CampaignId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Survey_ca__Campa__22751F6C"),
                        r => r.HasOne<Survey>().WithMany().HasForeignKey("SurveyId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Survey_ca__Surve__2180FB33"),
                        j =>
                        {
                            j.HasKey("SurveyId", "CampaignId").HasName("PK__Survey_c__423984FD4E7E4292");

                            j.ToTable("Survey_campaign");

                            j.IndexerProperty<int>("SurveyId").HasColumnName("Survey_id");

                            j.IndexerProperty<int>("CampaignId").HasColumnName("Campaign_id");
                        });

                entity.HasMany(d => d.QuestionsNavigation)
                    .WithMany(p => p.Surveys)
                    .UsingEntity<Dictionary<string, object>>(
                        "SurveyQuestion",
                        l => l.HasOne<Question>().WithMany().HasForeignKey("QuestionId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Survey_qu__Quest__1AD3FDA4"),
                        r => r.HasOne<Survey>().WithMany().HasForeignKey("SurveyId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Survey_qu__Surve__19DFD96B"),
                        j =>
                        {
                            j.HasKey("SurveyId", "QuestionId").HasName("PK__Survey_q__970ECE772014BA73");

                            j.ToTable("Survey_question");

                            j.IndexerProperty<int>("SurveyId").HasColumnName("Survey_id");

                            j.IndexerProperty<int>("QuestionId").HasColumnName("Question_id");
                        });

                entity.HasMany(d => d.Users)
                    .WithMany(p => p.Surveys)
                    .UsingEntity<Dictionary<string, object>>(
                        "SurveyDetail",
                        l => l.HasOne<Account>().WithMany().HasForeignKey("User").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Survey_det__User__4316F928"),
                        r => r.HasOne<Survey>().WithMany().HasForeignKey("SurveyId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Survey_de__Surve__4222D4EF"),
                        j =>
                        {
                            j.HasKey("SurveyId", "User").HasName("PK__Survey_d__77D7FC13D74FAA39");

                            j.ToTable("Survey_detail");

                            j.IndexerProperty<int>("SurveyId").HasColumnName("Survey_id");
                        });
            });

            modelBuilder.Entity<SurveyRequest>(entity =>
            {
                entity.ToTable("Survey_request");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateEnd)
                    .HasColumnType("date")
                    .HasColumnName("Date_end");

                entity.Property(e => e.DateStart)
                    .HasColumnType("date")
                    .HasColumnName("Date_start");

                entity.Property(e => e.SurveyId).HasColumnName("Survey_id");

                entity.Property(e => e.Title).HasMaxLength(250);

                entity.HasOne(d => d.ReceiverNavigation)
                    .WithMany(p => p.SurveyRequests)
                    .HasForeignKey(d => d.Receiver)
                    .HasConstraintName("FK__Survey_re__Recei__46E78A0C");

                entity.HasOne(d => d.Survey)
                    .WithMany(p => p.SurveyRequests)
                    .HasForeignKey(d => d.SurveyId)
                    .HasConstraintName("FK__Survey_re__Surve__45F365D3");

                entity.HasMany(d => d.Permissions)
                    .WithMany(p => p.SurveyRequests)
                    .UsingEntity<Dictionary<string, object>>(
                        "SurveyRequestPermission",
                        l => l.HasOne<Permission>().WithMany().HasForeignKey("PermissionId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Survey_re__Permi__7E37BEF6"),
                        r => r.HasOne<SurveyRequest>().WithMany().HasForeignKey("SurveyRequestId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Survey_re__Surve__7D439ABD"),
                        j =>
                        {
                            j.HasKey("SurveyRequestId", "PermissionId").HasName("PK__Survey_r__689610EA11D8841D");

                            j.ToTable("Survey_request_Permission");

                            j.IndexerProperty<int>("SurveyRequestId").HasColumnName("Survey_request_id");

                            j.IndexerProperty<int>("PermissionId").HasColumnName("Permission_id");
                        });
            });

            modelBuilder.Entity<SurveyResponse>(entity =>
            {
                entity.ToTable("Survey_response");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AccountId).HasColumnName("Account_id");

                entity.Property(e => e.SurveyId).HasColumnName("Survey_id");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.SurveyResponses)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Survey_re__Accou__17036CC0");

                entity.HasOne(d => d.Survey)
                    .WithMany(p => p.SurveyResponses)
                    .HasForeignKey(d => d.SurveyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Survey_re__Surve__160F4887");

                entity.HasMany(d => d.Answers)
                    .WithMany(p => p.SurveyResponses)
                    .UsingEntity<Dictionary<string, object>>(
                        "SurveyResponseAnswer",
                        l => l.HasOne<Answer>().WithMany().HasForeignKey("AnswerId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Survey_re__Answe__1EA48E88"),
                        r => r.HasOne<SurveyResponse>().WithMany().HasForeignKey("SurveyResponseId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Survey_re__Surve__1DB06A4F"),
                        j =>
                        {
                            j.HasKey("SurveyResponseId", "AnswerId").HasName("PK__Survey_r__D6890E4AC3711C81");

                            j.ToTable("Survey_response_answer");

                            j.IndexerProperty<int>("SurveyResponseId").HasColumnName("Survey_response_id");

                            j.IndexerProperty<int>("AnswerId").HasColumnName("Answer_id");
                        });
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("Task");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateEnd)
                    .HasColumnType("date")
                    .HasColumnName("Date_end");

                entity.Property(e => e.DateStart)
                    .HasColumnType("date")
                    .HasColumnName("Date_start");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.File).HasMaxLength(250);

                entity.Property(e => e.Title).HasMaxLength(250);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Task__CategoryId__37A5467C");

                entity.HasOne(d => d.ImplementNavigation)
                    .WithMany(p => p.TaskImplementNavigations)
                    .HasForeignKey(d => d.Implement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Task__Implement__36B12243");

                entity.HasOne(d => d.ReportNavigation)
                    .WithMany(p => p.TaskReportNavigations)
                    .HasForeignKey(d => d.Report)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Task__Report__35BCFE0A");
            });

            modelBuilder.Entity<UserList>(entity =>
            {
                entity.ToTable("User_list");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.NameFile)
                    .HasMaxLength(250)
                    .HasColumnName("Name_file");
            });

            modelBuilder.Entity<Visit>(entity =>
            {
                entity.ToTable("Visit");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateTime).HasColumnType("date");

                entity.Property(e => e.DistributorId).HasColumnName("Distributor_id");

                entity.Property(e => e.Intent).HasMaxLength(250);

                entity.Property(e => e.TaskId).HasColumnName("Task_id");

                entity.HasOne(d => d.CreatorNavigation)
                    .WithMany(p => p.VisitCreatorNavigations)
                    .HasForeignKey(d => d.Creator)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Visit__Creator__534D60F1");

                entity.HasOne(d => d.Distributor)
                    .WithMany(p => p.Visits)
                    .HasForeignKey(d => d.DistributorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Visit__Distribut__5535A963");

                entity.HasOne(d => d.GuestNavigation)
                    .WithMany(p => p.VisitGuestNavigations)
                    .HasForeignKey(d => d.Guest)
                    .HasConstraintName("FK__Visit__Guest__5441852A");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.Visits)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Visit__Task_id__5629CD9C");
            });

            modelBuilder.Entity<VisitActivity>(entity =>
            {
                entity.ToTable("Visit_activity");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ActivityType).HasColumnName("Activity_type");

                entity.Property(e => e.DateTime).HasColumnType("date");

                entity.Property(e => e.Note).HasMaxLength(1000);

                entity.Property(e => e.VisitId).HasColumnName("Visit_id");

                entity.HasOne(d => d.Visit)
                    .WithMany(p => p.VisitActivities)
                    .HasForeignKey(d => d.VisitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Visit_act__Visit__5DCAEF64");
            });

            modelBuilder.Entity<VisitChangeNotification>(entity =>
            {
                entity.ToTable("Visit_change_notification");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Content).HasMaxLength(1000);

                entity.Property(e => e.Created).HasColumnType("date");

                entity.Property(e => e.Title).HasMaxLength(250);

                entity.Property(e => e.VisitChangeRequestId).HasColumnName("Visit_change_request_id");

                entity.HasOne(d => d.VisitChangeRequest)
                    .WithMany(p => p.VisitChangeNotifications)
                    .HasForeignKey(d => d.VisitChangeRequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Visit_cha__Visit__6C190EBB");
            });

            modelBuilder.Entity<VisitChangeRequest>(entity =>
            {
                entity.ToTable("Visit_change_request");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ChangeType).HasColumnName("Change_type");

                entity.Property(e => e.DateEndNew)
                    .HasColumnType("date")
                    .HasColumnName("Date_end_new");

                entity.Property(e => e.DateEndOld)
                    .HasColumnType("date")
                    .HasColumnName("Date_end_old");

                entity.Property(e => e.DateStartNew)
                    .HasColumnType("date")
                    .HasColumnName("Date_start_new");

                entity.Property(e => e.DateStartOld)
                    .HasColumnType("date")
                    .HasColumnName("Date_start_old");

                entity.Property(e => e.VisitId).HasColumnName("Visit_id");

                entity.HasOne(d => d.ApproverNavigation)
                    .WithMany(p => p.VisitChangeRequestApproverNavigations)
                    .HasForeignKey(d => d.Approver)
                    .HasConstraintName("FK__Visit_cha__Appro__68487DD7");

                entity.HasOne(d => d.RequesterNavigation)
                    .WithMany(p => p.VisitChangeRequestRequesterNavigations)
                    .HasForeignKey(d => d.Requester)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Visit_cha__Reque__6754599E");

                entity.HasOne(d => d.Visit)
                    .WithMany(p => p.VisitChangeRequests)
                    .HasForeignKey(d => d.VisitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Visit_cha__Visit__693CA210");
            });

            modelBuilder.Entity<VisitPlan>(entity =>
            {
                entity.ToTable("Visit_plan");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateTime).HasColumnType("date");

                entity.Property(e => e.DistributorId).HasColumnName("Distributor_id");

                entity.HasOne(d => d.ApproverNavigation)
                    .WithMany(p => p.VisitPlanApproverNavigations)
                    .HasForeignKey(d => d.Approver)
                    .HasConstraintName("FK__Visit_pla__Appro__5AEE82B9");

                entity.HasOne(d => d.Distributor)
                    .WithMany(p => p.VisitPlans)
                    .HasForeignKey(d => d.DistributorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Visit_pla__Distr__59063A47");

                entity.HasOne(d => d.RequesterNavigation)
                    .WithMany(p => p.VisitPlanRequesterNavigations)
                    .HasForeignKey(d => d.Requester)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Visit_pla__Reque__59FA5E80");
            });

            modelBuilder.Entity<VisitReminder>(entity =>
            {
                entity.ToTable("Visit_reminder");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateTime).HasColumnType("date");

                entity.Property(e => e.ReminderTime).HasColumnName("Reminder_time");

                entity.Property(e => e.VisitId).HasColumnName("Visit_id");

                entity.HasOne(d => d.Visit)
                    .WithMany(p => p.VisitReminders)
                    .HasForeignKey(d => d.VisitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Visit_rem__Visit__6477ECF3");
            });

            modelBuilder.Entity<VisitRequest>(entity =>
            {
                entity.ToTable("Visit_request");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateEnd)
                    .HasColumnType("date")
                    .HasColumnName("Date_end");

                entity.Property(e => e.DateStart)
                    .HasColumnType("date")
                    .HasColumnName("Date_start");

                entity.Property(e => e.Title).HasMaxLength(250);

                entity.Property(e => e.VisitorId).HasColumnName("Visitor_id");

                entity.HasOne(d => d.RequesterNavigation)
                    .WithMany(p => p.VisitRequestRequesterNavigations)
                    .HasForeignKey(d => d.Requester)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Visit_req__Reque__619B8048");

                entity.HasOne(d => d.Visitor)
                    .WithMany(p => p.VisitRequestVisitors)
                    .HasForeignKey(d => d.VisitorId)
                    .HasConstraintName("FK__Visit_req__Visit__60A75C0F");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
