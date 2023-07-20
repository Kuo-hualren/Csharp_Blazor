using DBdesign.Shared;

namespace DBdesign.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Employees>().HasData(
                new Employees { Id = 1, Name = "Ben", Phone = "0966666666", Email = "sss@gmail.com", Position = "engineer", PunchId = 1 },
                new Employees { Id = 2, Name = "Alan", Phone = "0977777777", Email = "sssss@gmail.com", Position = "engineer", PunchId = 2 }
            );

            modelBuilder.Entity<Punchs1>().HasData(
                new Punchs1 { Id = 1, Name = "Ben", Time = "2023/07/19", PunchIn = DateTime.Now, PunchOut = DateTime.Now, Hours = "", PunchId = 1 },
                new Punchs1 { Id = 2, Name = "Ben", Time = "2023/07/19", PunchIn = DateTime.Now, PunchOut = DateTime.Now, Hours = "", PunchId = 1 }
            );

            modelBuilder.Entity<Punchs2>().HasData(
                new Punchs2 { Id = 1, Name = "Alan", Time = "2023/07/19", PunchIn = DateTime.Now, PunchOut = DateTime.Now, Hours = "", PunchId = 2 }
            );

            modelBuilder.Entity<Punchs1>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Punchs2>().Property(p => p.Id).ValueGeneratedOnAdd();


            //modelBuilder.Entity<Punchs1>()
            //.HasOne(p => p.Employee)
            //.WithMany(e => e.Punch1)
            //.HasForeignKey(p => p.PunchId);
            //modelBuilder.Entity<Punchs1>().Ignore(a => a.Employee);

            //modelBuilder.Entity<Punchs2>()
            //.HasOne(p => p.Employee)
            //.WithMany(e => e.Punch2)
            //.HasForeignKey(p => p.PunchId);
            //modelBuilder.Entity<Punchs2>().Ignore(a => a.Employee);



        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        public DbSet<Employees> Employees { get; set; }

        public DbSet<Punchs1> Punchs1 { get; set; }
        public DbSet<Punchs2> Punchs2 { get; set; }

    }
}
