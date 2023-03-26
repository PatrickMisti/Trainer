
namespace Trainer_backend.Persistence
{
    public class DbInitializer
    {
       public static void Run(DatabaseContext context) 
       { 
            if (!context.Database.EnsureCreated())
            {

            }
            context.SaveChanges();
        }
    }
}
