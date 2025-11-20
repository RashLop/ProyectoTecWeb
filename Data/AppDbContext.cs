using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProyectoTecWeb.Models;

namespace ProyectoTecWeb.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) { }

        public DbSet<User> users => Set<User>();
<<<<<<< HEAD
        public DbSet<Doctor> doctors => Set<Doctor>(); 
=======
        public DbSet<Appointment> appointments => Set<Appointment>();
>>>>>>> feat/citas

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>( u =>{
                u.HasKey(u => u.Id);
                u.Property(u => u.Email).IsRequired();
                u.Property(u => u.Password).IsRequired();
                u.Property(u => u.UserName).IsRequired(); 
                u.Property(u => u.Phone).IsRequired().HasMaxLength(8);
                u.Property(u => u.Role).IsRequired().HasDefaultValue("User");
                u.HasIndex(u => u.Email).IsUnique(); 
<<<<<<< HEAD
            }); 

            modelBuilder.Entity<Doctor>(d =>
            {
                d.HasKey(d => d.DoctorId); 
                d.Property(d => d.Name).IsRequired().HasMaxLength(50); 
                d.Property(d => d.Phone).IsRequired().HasMaxLength(50); 
                d.Property(d => d.Specialty).IsRequired().HasMaxLength(100);
                d.HasOne( u => u.user)
                .WithOne().HasForeignKey<Doctor>(u => u.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            }); 
=======
            });


            modelBuilder.Entity<Appointment>(a =>
            {
                a.HasKey(a => a.AppointmentId);
                a.Property(a => a.Reason).IsRequired().HasMaxLength(200);
                a.Property(a => a.Status).IsRequired();
            });
>>>>>>> feat/citas
        }
    }
}