using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using REST.Models;

namespace REST.DataLayer
{
    public class BatchesDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ApplicantOccupation> ApplicantOccupations { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<ApplicantSkill> ApplicantSkills { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Need> Needs { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SkillNeed> SkillNeeds { get; set; }
        public DbSet<ClientUser> ClientUsers { get; set; }
        public BatchesDBContext() { }


        public BatchesDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
              modelBuilder.Entity<User>()
              .Property(u=>u.UserId)
              .ValueGeneratedOnAdd();

              modelBuilder.Entity<ApplicantOccupation>()
              .Property(ao=>ao.ApplicantOccupationId)
              .ValueGeneratedOnAdd();

              modelBuilder.Entity<Application>()
              .Property(a=>a.ApplicationId)
              .ValueGeneratedOnAdd();

              modelBuilder.Entity<Interview>()
              .Property(i=>i.InterviewId)
              .ValueGeneratedOnAdd();

              modelBuilder.Entity<Applicant>()
              .Property(a=>a.ApplicantId)
              .ValueGeneratedOnAdd();

              modelBuilder.Entity<ApplicantSkill>()
              .Property(a=>a.ApplicantSkillId)
              .ValueGeneratedOnAdd();

              modelBuilder.Entity<Client>()
              .Property(c=>c.ClientId)
              .ValueGeneratedOnAdd();

              modelBuilder.Entity<Need>()
              .Property(n=>n.NeedId)
              .ValueGeneratedOnAdd();

              modelBuilder.Entity<Owner>()
              .Property(o=>o.OwnerId)
              .ValueGeneratedOnAdd();

              modelBuilder.Entity<Skill>()
              .Property(s=>s.SkillId)
              .ValueGeneratedOnAdd();

              modelBuilder.Entity<SkillNeed>()
              .Property(s=>s.SkillNeedId)
              .ValueGeneratedOnAdd();

              modelBuilder.Entity<ClientUser>()
              .Property(cu=>cu.ClientUserId)
              .ValueGeneratedOnAdd();

        }


    }
}