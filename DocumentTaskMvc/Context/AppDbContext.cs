namespace DocumentTaskMvc.Context
{
    using DocumentTaskMvc.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection.Metadata;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Entity> Entities { get; set; }
        public DbSet<Models.Document> Documents { get; set; }
       
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
