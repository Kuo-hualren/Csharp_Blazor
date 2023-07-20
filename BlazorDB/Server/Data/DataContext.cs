
using BlazorDB.Client.Pages;

namespace BlazorDB.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //public DbSet<Employee> Employees { get; set; }
            //public DbSet<Record> Records { get; set; }

            //modelBuilder.Entity<Record>().HasData(
            //    new Record { Id = 1, Name = "Ben", Time = DateTime.Today.ToString("yyyy/MM/dd"), PunchIn = DateTime.Now, PunchOut = DateTime.Now, Hours = "0" },
            //    new Record { Id = 2, Name = "Alan", Time = DateTime.Today.ToString("yyyy/MM/dd"), PunchIn = DateTime.Now, PunchOut = DateTime.Now, Hours = "0" }
            //);


            //modelBuilder.Entity<Employee>().HasData(
            //    new Employee { Id = 1, Name = "Ben", Phone = "0966666666", Email = "sss@gmail.com", Position = "engineer", RecordId = 1 },
            //    new Employee { Id = 2, Name = "Alan", Phone = "0977777777", Email = "sssss@gmail.com", Position = "engineer", RecordId = 2 }
            //);


            modelBuilder.Entity<Emps>().HasData(
               new Emps { Id = 1, Name = "Ben", Phone = "0966666666", Email = "sss@gmail.com", Position = "engineer", PunchId = 1 },
               new Emps { Id = 2, Name = "Alan", Phone = "0977777777", Email = "sssss@gmail.com", Position = "engineer", PunchId = 2 },
               new Emps { Id = 3, Name = "Cann", Phone = "0977776879", Email = "aaaa@gmail.com", Position = "engineer", PunchId = 3 }
           );

            modelBuilder.Entity<PunR1>().ToTable("Punchs1").HasData(
                new PunR1 { Id = 1, Name = "Ben", Time = "2023/07/19", PunchIn = DateTime.Now, PunchOut = DateTime.Now, Hours = "", PunchId = 1 },
                new PunR1 { Id = 2, Name = "Ben", Time = "2023/07/19", PunchIn = DateTime.Now, PunchOut = DateTime.Now, Hours = "", PunchId = 1 }
            );

            modelBuilder.Entity<PunR2>().ToTable("Punchs2").HasData(
                new PunR2 { Id = 1, Name = "Alan", Time = "2023/07/19", PunchIn = DateTime.Now, PunchOut = DateTime.Now, Hours = "", PunchId = 2 }
            );

            modelBuilder.Entity<PunR3>().ToTable("Punchs2").HasData(
                new PunR3 { Id = 1, Name = "Cann", Time = "2023/07/19", PunchIn = DateTime.Now, PunchOut = DateTime.Now, Hours = "", PunchId = 3 }
            );

            modelBuilder.Entity<PunR1>()
            .HasOne(p => p.Employee)
            .WithMany(e => e.Punch1)
            .HasForeignKey(p => p.PunchId);

            modelBuilder.Entity<PunR2>()
            .HasOne(p => p.Employee)
            .WithMany(e => e.Punch2)
            .HasForeignKey(p => p.PunchId);

            modelBuilder.Entity<PunR3>()
            .HasOne(p => p.Employee)
            .WithMany(e => e.Punch3)
            .HasForeignKey(p => p.PunchId);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        public DbSet<Employees> Employees { get; set; }

        public DbSet<PunR1> Punchs1 { get; set; }
        public DbSet<PunR2> Punchs2 { get; set; }
        public DbSet<PunR3> Punchs3 { get; set; }


    }
}
