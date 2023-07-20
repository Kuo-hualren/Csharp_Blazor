

using EmployRec.Shared;

namespace EmployRec.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Emplo>().HasData(
                new Emplo { Id = 1, Name = "Ben", Phone = "0966666666", Email = "sss@gmail.com", Position = "engineer", PunchId = 1 },
                new Emplo { Id = 2, Name = "Alan", Phone = "0977777777", Email = "sssss@gmail.com", Position = "engineer", PunchId = 2 }
            );

            modelBuilder.Entity<Puns1>().HasData(
                new Puns1 { Id = 1, Name = "Ben", Time = "2023/07/19", PunchIn = DateTime.Now, PunchOut = DateTime.Now, Hours = "", PunchId = 1 },
                new Puns1 { Id = 2, Name = "Ben", Time = "2023/07/19", PunchIn = DateTime.Now, PunchOut = DateTime.Now, Hours = "", PunchId = 1 }
            );

            modelBuilder.Entity<Puns2>().HasData(
                new Puns2 { Id = 1, Name = "Alan", Time = "2023/07/19", PunchIn = DateTime.Now, PunchOut = DateTime.Now, Hours = "", PunchId = 2 }
            );

            modelBuilder.Entity<Puns1>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Puns2>().Property(p => p.Id).ValueGeneratedOnAdd();



        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        public DbSet<Emplo> Employees { get; set; }

        public DbSet<Puns1> Punchs1 { get; set; }
        public DbSet<Puns2> Punchs2 { get; set; }

    }
}
