using Microsoft.EntityFrameworkCore;
using Trainer_backend.Model;
using Trainer_backend.Persistence.Configuration;

namespace Trainer_backend.Persistence
{
    public class DatabaseContext: DbContext
    {
        public readonly string _connectionString = "Host=localhost;Database=Trainer;Port=5432;Username=app;Password=app;";

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DatabaseContext() : this(new DbContextOptionsBuilder<DatabaseContext>().Options) { }

        public DatabaseContext(string? connectionString) : this(new DbContextOptionsBuilder<DatabaseContext>().Options)
        {
            if (connectionString != null)
            {
                _connectionString = connectionString;
            }
        }

        
        public DbSet<WorkSet> WorkSets { get; set; }
        public DbSet<Set> Sets { get; set; }
        public DbSet<Routine> Routines { get; set; }

        #region DB creating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            ConfigurationTable(modelBuilder);
            Initializer(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseNpgsql(_connectionString, options => options.EnableRetryOnFailure(2))
                .EnableSensitiveDataLogging();

            base.OnConfiguring(optionsBuilder);
        }

        private void ConfigurationTable(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SetConfiguration());
            modelBuilder.ApplyConfiguration(new WorkSetConfiguration());
            modelBuilder.ApplyConfiguration(new RoutineConfiguration());
        }

        private void Initializer(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Set>();
            modelBuilder.Entity<WorkSet>();
            modelBuilder.Entity<Routine>();
        }
        #endregion

        public static DbContext CreateDatabase(DbContext context) // todo maybe Database class
        {
            bool isCreated = false;

            if (context.Database == null)
                throw new InvalidOperationException();

            try
            {
                isCreated = context.Database.CanConnect();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            if (isCreated)
            {
                // versionierung
            }

            try
            {
                void FillContext(DbContext context)
                {
                    var s1 = new Set()
                    {
                        Repetition = 10,
                        Weight = 30.2
                    };
                    context.Set<Set>().Add(s1);
                    context.SaveChanges();

                    var r1 = new Routine()
                    {
                        Date = DateTime.Now,
                        //Working = new List<WorkSet>() { w1 }
                    };
                    context.Set<Routine>().Add(r1);

                    context.SaveChanges();

                    var w1 = new WorkSet()
                    {
                        Name = "Latziehen",
                        Sets = new List<Set>() { s1 },
                        RoutineId = r1.Id
                    };
                    context.Set<WorkSet>().Add(w1);
                    context.SaveChanges();
                    
                }

                context.Database.EnsureCreated();
                context.SaveChanges();
                //FillContext(context);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return context;
        }
    }
}
