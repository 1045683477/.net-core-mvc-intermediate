using Microsoft.EntityFrameworkCore;
using TutorialStudy.Model;

namespace TutorialStudy.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
            
        }

        public DbSet<Student> Students { get; set; }
    }
}
