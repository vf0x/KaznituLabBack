using System;
using System.Collections.Generic;
using System.Text;
using EFData.Entity;
using EFData.HrEntity;
using EFData.Seed;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EFData.Context
{
    public class KaznituLabContext : IdentityDbContext<AppUser>
    {
        public KaznituLabContext(DbContextOptions<KaznituLabContext> options)
            : base(options)
        {

        }
        //protected KaznituLabContext(DbContextOptions options)
        //    : base(options)
        //{
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<IdentityUserLogin<string>>();
            modelBuilder.Ignore<IdentityUserClaim<string>>();
            modelBuilder.Ignore<IdentityUserToken<string>>();
            modelBuilder.Ignore<IdentityRoleClaim<string>>();
            modelBuilder.Ignore<QueryDictionary>();
            modelBuilder.Entity<QueryDictionary>().HasNoKey().ToView("view_name_that_doesnt_exist");

            modelBuilder
                .Entity<ProjectFundingCoFinancing>() 
                .HasOne(e => e.CurrencyType)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "95FEE468-4DA9-40F6-AACB-42951BBABAF9",
                Name = "Admin",
                NormalizedName = "ADMIN"
            });

            //LaboratoryStatus
            modelBuilder.Entity<LaboratoryStatus>().HasData(new LaboratoryStatus
            {
                Id = 1,
                Title = "Действует"
            },
            new LaboratoryStatus
            {
                Id = 2,
                Title = "Не Действует"
            });

            //ProjectStatus
            modelBuilder.Entity<ProjectStatus>().HasData(new ProjectStatus
            {
                Id = 1,
                Title = "Действует"
            },
            new LaboratoryStatus
            {
                Id = 2,
                Title = "Не Действует"
            });

            //EquipmentStatus
            modelBuilder.Entity<EquipmentStatus>().HasData(new LaboratoryStatus
            {
                Id = 1,
                Title = "Исправное"
            },
            new LaboratoryStatus
            {
                Id = 2,
                Title = "Техобслуживание"
            },
            new LaboratoryStatus
            {
                Id = 3,
                Title = "Ремонт"
            },
            new LaboratoryStatus
            {
                Id = 4,
                Title = "Списание"
            });

            //FinancingType
            modelBuilder.Entity<FinancingType>().HasData(new FinancingType
            {
                Id = 1,
                Title = "Заём"
            },
            new LaboratoryStatus
            {
                Id = 2,
                Title = "Кредит"
            },
            new LaboratoryStatus
            {
                Id = 3,
                Title = "Ссуда"
            },
            new LaboratoryStatus
            {
                Id = 4,
                Title = "Аренда"
            },
            new LaboratoryStatus
            {
                Id = 5,
                Title = "Пожертвование, Дарение"
            },
            new LaboratoryStatus
            {
                Id = 6,
                Title = "Субсидия"
            },
            new LaboratoryStatus
            {
                Id = 7,
                Title = "Субвенция"
            },
            new LaboratoryStatus
            {
                Id = 8,
                Title = "Дотация"
            },
            new LaboratoryStatus
            {
                Id = 9,
                Title = "Грант"
            });

            // CurrencyType
            modelBuilder.Entity<CurrencyType>().HasData(new CurrencyType
            {
                Id = 1,
                Title = "₸ KZT"
            },
            new LaboratoryStatus
            {
                Id = 2,
                Title = "$ USD"
            },
            new LaboratoryStatus
            {
                Id = 3,
                Title = "₽ RUB"
            },
            new LaboratoryStatus
            {
                Id = 4,
                Title = "€ EUR"
            });

            //BibliographicDbType
            modelBuilder.Entity<BibliographicDbType>().HasData(new BibliographicDbType
            {
                Id = 1,
                Title = "Scopus"
            },
            new LaboratoryStatus
            {
                Id = 2,
                Title = "WoS"
            });

            //WorkType
            modelBuilder.Entity<WorkType>().HasData(new WorkType
            {
                Id = 1,
                Title = "Научная статья"
            },
            new LaboratoryStatus
            {
                Id = 2,
                Title = "Реферат"
            },
            new LaboratoryStatus
            {
                Id = 3,
                Title = "Доклад"
            },
            new LaboratoryStatus
            {
                Id = 4,
                Title = "Депонированная статья"
            },
            new LaboratoryStatus
            {
                Id = 5,
                Title = "Сборник научных трудов"
            },
            new LaboratoryStatus
            {
                Id = 6,
                Title = "Учебник"
            },
            new LaboratoryStatus
            {
                Id = 7,
                Title = "Монография"
            });




        }
        public DbSet<User> User { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Laboratory> Laboratories { get; set; }
        public DbSet<LaboratoryEmployee> LaboratoryEmployees { get; set; }
        public DbSet<LaboratoryEqiupment> LaboratoryEqiupments { get; set; }
        public DbSet<LaboratoryService> LaboratoryServices { get; set; }
        public DbSet<LaboratoryStatus> LaboratoryStatuses { get; set; }
        public DbSet<LaboratoryProject> LaboratoryProjects { get; set; }
        public DbSet<QueryDictionary> Dictionaries { get; set; }
        public DbSet<EquipmentStatus> EquipmentStatuses { get; set; }
        public DbSet<EquipmentTechnicalMaintenance> EquipmentTechnicalMaintenances { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectStatus> ProjectStatuses { get; set; }
        public DbSet<ProjectEmployee> ProjectEmployees { get; set; }
        public DbSet<ProjectCustomer> ProjectCustomers { get; set; }
        public DbSet<ProjectContract> ProjectContracts { get; set; }
        public DbSet<ProjectRevenue> ProjectRevenues { get; set; }
        public DbSet<ProjectPatent> ProjectPatents { get; set; }
        public DbSet<ProjectCertificateRegistration> ProjectCertificateRegistrations { get; set; }
        public DbSet<ProjectFunding> ProjectFundings { get; set; }
        public DbSet<ProjectFundingStage> ProjectFundingStages { get; set; }
        public DbSet<ProjectFundingCoFinancing> ProjectFundingCoFinancings { get; set; }
        public DbSet<BibliographicDbType> BibliographicDbTypes { get; set; }
        public DbSet<CurrencyType> CurrencyTypes { get; set; }
        public DbSet<FinancingType> FinancingTypes { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<WorkType> WorkTypes { get; set; }
        public DbSet<WorkCoAuthor> WorkCoAuthors { get; set; }
        public DbSet<WorkBibliographicDbType> WorkBibliographicDbTypes { get; set; }
    }
}
