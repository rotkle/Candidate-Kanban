using Kanban.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kanban.Api.Helpers
{
    /// <summary>
    /// Database context which is used to interact with MySql database by connection string
    /// </summary>
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext()
        {
        }

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

        public virtual DbSet<Candidate> Candidates { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<CandidateJob> CandidateJobs { get; set; }
    }
}