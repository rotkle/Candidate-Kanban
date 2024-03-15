using Kanban.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kanban.Api.Helpers
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to mysql with connection string from app settings
            var connectionString = Configuration.GetConnectionString("WebApiDatabase");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<CandidateJob> CandidateJobs { get; set; }
    }
}