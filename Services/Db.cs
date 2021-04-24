using app_net_docker.Models;
using Microsoft.EntityFrameworkCore;

namespace app_net_docker.Services
{
    public class Db: DbContext
    {
        public Db(DbContextOptions<Db> options): base(options)
        {           
            Database.EnsureCreated(); 
        }

        public DbSet<Todo> Todo {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>(x => {
                x.ToTable("todos");
                x.HasKey(x => x.Id);
                x.Property(x => x.Id)
                    .HasColumnName("id");
                x.Property(x => x.Description)
                    .HasColumnName("description")
                    .IsRequired();
            });
        }
    }
}