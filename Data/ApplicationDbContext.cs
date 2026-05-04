using Microsoft.EntityFrameworkCore;
using crudpractice.Model;
namespace crudpractice.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
      : base(options)
        {
        }
        public DbSet<Employee> emp { get; set; }
        //table remain code
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map the entity 'Student' to the exact table name 'tbl_Students'
            modelBuilder.Entity<Employee>()
                        .ToTable("Employee");


        }
    }
}
