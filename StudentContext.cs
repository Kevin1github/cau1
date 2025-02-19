using System.Data.Entity;

namespace ett1_win
{
    public class StudentContext : DbContext
    {
        public StudentContext() : base("StudentDBConnectionString") { }

        public DbSet<Student> Students { get; set; }
    }
}
