using BuildWeek5_Team5.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BuildWeek5_Team5.Data {
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>, ApplicationUserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>> {

        public ApplicationDbContext() {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
        }

        public DbSet<ApplicationUser> ApplicationUsers {
            get; set;
        }

        public DbSet<ApplicationRole> ApplicationRoles {
            get; set;
        }

        public DbSet<ApplicationUserRole> ApplicationUserRoles {
            get; set;
        }

        public DbSet<Animale> Animali {
            get; set;
        }

        public DbSet<AnimaleSmarrito> AnimaliSmarriti {
            get; set;
        }

        public DbSet<Armadietto> Armadietti {
            get; set;
        }

        public DbSet<Prodotto> Prodotti {
            get; set;
        }

        public DbSet<Ricovero> Ricoveri {
            get; set;
        }

        public DbSet<Vendita> Vendite {
            get; set;
        }

        public DbSet<Visita> Visite {
            get; set;
        }

        public DbSet<Cassetto> Cassetti
        {
            get; set;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUserRole>().HasOne(ur => ur.User).WithMany(u => u.ApplicationUserRoles).HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<ApplicationUserRole>().HasOne(ur => ur.Role).WithMany(r => r.ApplicationUserRole).HasForeignKey(ur => ur.RoleId);

            modelBuilder.Entity<ApplicationUserRole>().Property(p => p.Date).HasDefaultValueSql("GETDATE()").IsRequired(true);

            modelBuilder.Entity<Ricovero>().Property(p => p.DataInizioRicovero).HasDefaultValueSql("GETDATE()").IsRequired(true);

            modelBuilder.Entity<Vendita>().Property(p => p.DataVendita).HasDefaultValueSql("GETDATE()").IsRequired(true);

            modelBuilder.Entity<Prodotto>().HasOne(p => p.Cassetto).WithMany(a => a.Prodotti).HasForeignKey(p => p.CassettoId);

            modelBuilder.Entity<Visita>().HasOne(v => v.Animale).WithMany(a => a.Visite).HasForeignKey(v => v.AnimaleId);

            modelBuilder.Entity<Visita>().HasOne(v => v.AnimaleSmarrito).WithMany(a => a.Visite).HasForeignKey(v => v.AnimaleSmarritoId);

            modelBuilder.Entity<AnimaleSmarrito>().HasOne(a => a.Ricovero).WithOne(r => r.AnimaleSmarrito).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Animale>().HasOne(a => a.Ricovero).WithOne(r => r.Animale).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AnimaleSmarrito>().HasIndex(a => a.NumeroMicrochip).IsUnique(true);

            modelBuilder.Entity<Animale>().HasIndex(a => a.NumeroMicrochip).IsUnique(true);

            modelBuilder.Entity<Armadietto>().HasMany(a => a.Cassetti).WithOne(c => c.Armadietto).HasForeignKey(c => c.ArmadiettoId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
