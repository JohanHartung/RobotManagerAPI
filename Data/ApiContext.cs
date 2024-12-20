using Microsoft.EntityFrameworkCore;
using RobotManagerAPI.Models;

namespace RobotManagerAPI.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }

        public DbSet<Nao> Naos { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<ClinicVisit> ClinicVisits { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Process> Processes { get; set; }
    }
}
