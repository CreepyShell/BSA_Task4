using LINQ.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LINQ.DataAccess
{
    public class LINQDbContext : DbContext
    {
        public LINQDbContext() { }
        public LINQDbContext(DbContextOptions<LINQDbContext> options) : base(options) { }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<User>()
                .HasMany(u => u.Tasks)
                .WithOne(u=>u.User)
                .HasForeignKey(t => t.PerformerId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<User>()
                .HasMany(u => u.Projects)
                .WithOne(pr=>pr.User)
                .HasForeignKey(pr => pr.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);


            //builder.Entity<Project>().Ignore(pr => pr.Deadline).Ignore(pr => pr.Description).Ignore(pr => pr.Deadline);
            //builder.Entity<Task>().Ignore(t => t.Description).Ignore(t => t.State).Ignore(t => t.FinishedAt);
            //builder.Entity<User>().Ignore(u => u.BirthDay).Ignore(u => u.Email);

            List<Team> teams = new List<Team>()
            {
                new Team(){Id = 1, Name="Bavarija", CreatedAt = System.DateTime.Now },
                new Team(){Id=2, Name="Stroiteli" , CreatedAt = System.DateTime.Now},
                new Team(){Id=3, Name ="Svarihciki", CreatedAt = System.DateTime.Now}
            };

            List<User> users = new List<User>()
            {
                new User(){Id=1, TeamId=1, Name="Dave", RegisteredAt = System.DateTime.Now},
                new User(){Id=2, TeamId=2, Name="Cristian", RegisteredAt = System.DateTime.Now},
                new User(){Id=3, TeamId=2, Name="Ronald", RegisteredAt = System.DateTime.Now},
                new User(){Id=4, TeamId=3, Name="Anna", RegisteredAt = System.DateTime.Now},
                new User(){Id=5, TeamId=3, Name="Steve", RegisteredAt = System.DateTime.Now},
                new User(){Id=6, TeamId=3, Name="Roshar", RegisteredAt = System.DateTime.Now}
            };

            List<Project> projects = new List<Project>()
            {
                new Project(){Id = 1, AuthorId=1, TeamId=1, Name="Stroika", CreatedAt = System.DateTime.Now},
                new Project(){Id = 2, AuthorId=3, TeamId=2, Name="Zavod", CreatedAt = System.DateTime.Now},
                new Project(){Id = 3, AuthorId=3, TeamId=3, Name="Doroga", CreatedAt = System.DateTime.Now},
            };

            List<Task> tasks = new List<Task>()
            {
                new Task(){Id=1, Name="Chinit dorogu", PerformerId = 6, ProjectId=3, CreatedAt = System.DateTime.Now},
                new Task(){Id=2, Name="Stroit dorogu", PerformerId = 6, ProjectId=3, CreatedAt = System.DateTime.Now},
                new Task(){Id=3, Name="Rabotat na zavode", PerformerId = 4, ProjectId = 2, CreatedAt = System.DateTime.Now},
                new Task(){Id=4, Name="Stroit doma", PerformerId = 4, ProjectId = 1, CreatedAt = System.DateTime.Now}
            };
            builder.Entity<Team>().HasData(teams);
            builder.Entity<User>().HasData(users);
            builder.Entity<Project>().HasData(projects);
            builder.Entity<Task>().HasData(tasks);

            base.OnModelCreating(builder);
        }
    }
}
