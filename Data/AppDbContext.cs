using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.EntityFrameworkCore;
using ProyectoTecWeb.Models;
using ProyectoTecWeb.Models.Patient;

namespace ProyectoTecWeb.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) { }

        public DbSet<User> users => Set<User>();
        public DbSet<Doctor> doctors => Set<Doctor>();
        public DbSet<Appointment> appointments => Set<Appointment>();

        public DbSet<Patient> patients => Set<Patient>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(u =>
            {
                u.HasKey(u => u.Id);
                u.Property(u => u.Email).IsRequired();
                u.Property(u => u.Password).IsRequired();
                u.Property(u => u.UserName).IsRequired();
                u.Property(u => u.Phone).IsRequired().HasMaxLength(8);
                u.Property(u => u.Role).IsRequired().HasDefaultValue("User");
                u.HasIndex(u => u.Email).IsUnique();
            });

            modelBuilder.Entity<Doctor>(d =>
            {
                d.HasKey(d => d.DoctorId);
                d.Property(d => d.Name).IsRequired().HasMaxLength(50);
                d.Property(d => d.Phone).IsRequired().HasMaxLength(50);
                d.Property(d => d.Specialty).IsRequired().HasMaxLength(100);
                d.HasOne(d => d.user)
                    .WithOne()
                    .HasForeignKey<Doctor>(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Appointment>(a =>
            {
                a.HasKey(a => a.AppointmentId);
                a.Property(a => a.Reason).IsRequired().HasMaxLength(200);
                a.Property(a => a.Status).IsRequired();
                a.HasOne(d => d.Doctor)
                    .WithMany(d => d.Appointments)
                    .HasForeignKey(a => a.DoctorId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<Appointment>(a =>
            {
                a.HasKey(a => a.AppointmentId);

                a.Property(a => a.Date).IsRequired();
                a.Property(a => a.Time).IsRequired();
                a.Property(a => a.Reason).IsRequired().HasMaxLength(200);
                a.Property(a => a.Status).IsRequired().HasDefaultValue(0);
                a.Property(a => a.Notes).HasMaxLength(500);

                // Relación: Appointment -> Doctor
                a.HasOne(a => a.Doctor)
                    .WithMany(d => d.Appointments)
                    .HasForeignKey(a => a.DoctorId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Relación: Appointment -> Patient
                a.HasOne(a => a.Patient)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(a => a.PatientId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
