using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.EntityFrameworkCore;
using ProyectoTecWeb.Models;

namespace ProyectoTecWeb.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) { }

        public DbSet<User> users => Set<User>();
        public DbSet<Doctor> doctors => Set<Doctor>();
        public DbSet<Appointment> appointments => Set<Appointment>();
        public DbSet<Consultorio> consultorios => Set<Consultorio>(); 

        public DbSet<Patient> patients => Set<Patient>();

        public DbSet<History> histories => Set<History>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(u =>
            {
                u.HasKey(u => u.Id);
                u.Property(u => u.Email).IsRequired();
                u.Property(u => u.Password).IsRequired();
                u.Property(u => u.UserName).IsRequired();
                u.Property(u => u.Role).IsRequired().HasDefaultValue("User");
                u.HasIndex(u => u.Email).IsUnique();
            });

            modelBuilder.Entity<Doctor>(d =>
            {
                d.HasKey(d => d.DoctorId);
                d.Property(d => d.Name).IsRequired().HasMaxLength(50);
                d.Property(d => d.Phone).IsRequired().HasMaxLength(8);
                d.Property(d => d.Specialty).IsRequired().HasMaxLength(100);
                d.HasOne(d => d.user)
                    .WithOne()
                    .HasForeignKey<Doctor>(d => d.UserId)
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
                a.HasOne(d => d.Doctor)
                    .WithMany(d => d.Appointments)
                    .HasForeignKey(a => a.DoctorId)
                    .OnDelete(DeleteBehavior.Restrict);
                a.HasOne(a => a.Patient)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(a => a.PatientId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<History>(h =>
            {
                h.HasKey(h => h.HistoryID);
                h.Property(h => h.BloodType)
                    .IsRequired()
                    .HasMaxLength(10);

                // Relaci�n:1-1
                h.HasOne(h => h.Patient)
                    .WithMany(p => p.Histories)
                    .HasForeignKey(h => h.PatientId) 
                    .OnDelete(DeleteBehavior.Cascade);

                // Configure collections as JSON columns
                h.Property(h => h.Diagnoses)
                    .HasConversion(
                        v => string.Join(',', v ?? new List<string>()),
                        v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
                    );
                h.Property(h => h.Medication)
                    .HasConversion(
                        v => string.Join(',', v ?? new List<string>()),
                        v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
                    );

                h.Property(h => h.Allergies)
                    .HasConversion(
                        v => string.Join(',', v ?? new List<string>()),
                        v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
                    );
                    
            });
            modelBuilder.Entity<Consultorio>(c =>
            {
                c.HasKey(c => c.ConsultorioId);
                c.Property(c => c.ConsultorioName).IsRequired().HasMaxLength(50);
                c.Property(c => c.Address).IsRequired().HasMaxLength(200);
                c.Property(c => c.Equipment).IsRequired().HasMaxLength(200);
                // RELACIÓN 1:1
                c.HasOne(c => c.Doctor)
                    .WithOne(d => d.Consultorio) 
                    .HasForeignKey<Consultorio>(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.Cascade); 
            });

            modelBuilder.Entity<Patient>(p =>
            {
                p.HasKey(p => p.PatientId); 
                p.Property(p => p.Name).IsRequired().HasMaxLength(20); 
                p.Property(p => p.Phone).IsRequired().HasMaxLength(8);
                p.HasOne(p => p.user)
                    .WithOne()
                    .HasForeignKey<Patient>(p => p.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            }); 

        }
    }
}
