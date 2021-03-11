using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using EFData.HrEntity;

#nullable disable

namespace EFData.Context
{
    public partial class HrContext : DbContext
    {
        public HrContext()
        {
        }

        public HrContext(DbContextOptions<HrContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AcademicDegree> AcademicDegrees { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeDetail> EmployeeDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderEmployee> OrderEmployees { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<SimpleDictionary> SimpleDictionaries { get; set; }
        public virtual DbSet<DictionaryModels> Dictionaries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("*");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Department>();
            modelBuilder.Ignore<Employee>();
            modelBuilder.Ignore<EmployeeDetail>();
            modelBuilder.Ignore<Order>();
            modelBuilder.Ignore<OrderEmployee>();
            modelBuilder.Ignore<Position>();
            modelBuilder.Ignore<SimpleDictionary>();
            modelBuilder.Ignore<DictionaryModels>();
            modelBuilder.Entity<DictionaryModels>().HasNoKey().ToView("view_name_that_doesnt_exist");
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<AcademicDegree>(entity =>
            {
                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateIssued).HasColumnType("date");

                entity.Property(e => e.DocumentNumber).HasMaxLength(100);

                entity.HasOne(d => d.AcademicDegreeNavigation)
                    .WithMany(p => p.AcademicDegreeAcademicDegreeNavigations)
                    .HasForeignKey(d => d.AcademicDegreeId)
                    .HasConstraintName("FK_AcademicDegrees_SimpleDictionaries");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.AcademicDegreeEmployees)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_AcademicDegrees_Employees");

                entity.HasOne(d => d.Speciality)
                    .WithMany(p => p.AcademicDegreeSpecialities)
                    .HasForeignKey(d => d.SpecialityId)
                    .HasConstraintName("FK_AcademicDegrees_SimpleDictionaries1");

                entity.HasOne(d => d.Supervisor)
                    .WithMany(p => p.AcademicDegreeSupervisors)
                    .HasForeignKey(d => d.SupervisorId)
                    .HasConstraintName("FK_AcademicDegrees_Employees1");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.Title).IsRequired();

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_Departments_Departments");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.AduserName).HasColumnName("ADUserName");

                entity.Property(e => e.CreatedInAd).HasColumnName("CreatedInAD");

                entity.Property(e => e.CreatedInSso).HasColumnName("CreatedInSSO");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Iin).HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.MiddleName).HasMaxLength(250);
            });

            modelBuilder.Entity<EmployeeDetail>(entity =>
            {
                entity.Property(e => e.FirstNameTranslit).HasMaxLength(250);

                entity.Property(e => e.ForeignerTermEndDate).HasColumnType("date");

                entity.Property(e => e.ForeignerTermStartDate).HasColumnType("date");

                entity.Property(e => e.LastNameTranslit).HasMaxLength(250);

                entity.Property(e => e.MiddleNameTranslit).HasMaxLength(250);

                entity.Property(e => e.PersonalCardIssueDate).HasColumnType("date");

                entity.Property(e => e.PersonalCardIssuer).HasMaxLength(250);

                entity.Property(e => e.PersonalCardNumber).HasMaxLength(50);

                entity.Property(e => e.PlaceOfBirth).HasMaxLength(500);

                entity.HasOne(d => d.Citizenship)
                    .WithMany(p => p.EmployeeDetailCitizenships)
                    .HasForeignKey(d => d.CitizenshipId)
                    .HasConstraintName("FK_EmployeeDetails_SimpleDictionaries3");

                entity.HasOne(d => d.Education)
                    .WithMany(p => p.EmployeeDetailEducations)
                    .HasForeignKey(d => d.EducationId)
                    .HasConstraintName("FK_EmployeeDetails_SimpleDictionaries6");

                entity.HasOne(d => d.EducationLanguage)
                    .WithMany(p => p.EmployeeDetailEducationLanguages)
                    .HasForeignKey(d => d.EducationLanguageId)
                    .HasConstraintName("FK_EmployeeDetails_SimpleDictionaries8");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeDetails)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_EmployeeDetails_Employees");

                entity.HasOne(d => d.EnglishLevel)
                    .WithMany(p => p.EmployeeDetailEnglishLevels)
                    .HasForeignKey(d => d.EnglishLevelId)
                    .HasConstraintName("FK_EmployeeDetails_SimpleDictionaries9");

                entity.HasOne(d => d.MaritalStatus)
                    .WithMany(p => p.EmployeeDetailMaritalStatuses)
                    .HasForeignKey(d => d.MaritalStatusId)
                    .HasConstraintName("FK_EmployeeDetails_SimpleDictionaries2");

                entity.HasOne(d => d.Nationality)
                    .WithMany(p => p.EmployeeDetailNationalities)
                    .HasForeignKey(d => d.NationalityId)
                    .HasConstraintName("FK_EmployeeDetails_SimpleDictionaries");

                entity.HasOne(d => d.PlaceOfBirthNavigation)
                    .WithMany(p => p.EmployeeDetailPlaceOfBirthNavigations)
                    .HasForeignKey(d => d.PlaceOfBirthId)
                    .HasConstraintName("FK_EmployeeDetails_SimpleDictionaries1");

                entity.HasOne(d => d.PublishedScientificArticleIndustry)
                    .WithMany(p => p.EmployeeDetailPublishedScientificArticleIndustries)
                    .HasForeignKey(d => d.PublishedScientificArticleIndustryId)
                    .HasConstraintName("FK_EmployeeDetails_SimpleDictionaries11");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.DateActual).HasColumnType("date");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateEnd).HasColumnType("date");

                entity.Property(e => e.DateIssued).HasColumnType("date");

                entity.Property(e => e.DateStart).HasColumnType("date");

                entity.Property(e => e.Number).HasMaxLength(150);

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_Orders_SimpleDictionaries2");
            });

            modelBuilder.Entity<OrderEmployee>(entity =>
            {
                entity.Property(e => e.Comment).HasMaxLength(1000);

                entity.Property(e => e.DateEnd).HasColumnType("date");

                entity.Property(e => e.DateStart).HasColumnType("date");

                entity.Property(e => e.NewFirstName).HasMaxLength(50);

                entity.Property(e => e.NewFirstNameTranslit).HasMaxLength(50);

                entity.Property(e => e.NewLastName).HasMaxLength(50);

                entity.Property(e => e.NewLastNameTranslit).HasMaxLength(50);

                entity.Property(e => e.NewMiddleName).HasMaxLength(50);

                entity.Property(e => e.NewMiddleNameTranslit).HasMaxLength(50);

                entity.HasOne(d => d.CancelingReason)
                    .WithMany(p => p.OrderEmployeeCancelingReasons)
                    .HasForeignKey(d => d.CancelingReasonId)
                    .HasConstraintName("OrderEmployees_FK_6");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.OrderEmployees)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("OrderEmployees_FK_2");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.OrderEmployees)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("OrderEmployees_FK_1");

                entity.HasOne(d => d.HiringCondition)
                    .WithMany(p => p.OrderEmployeeHiringConditions)
                    .HasForeignKey(d => d.HiringConditionId)
                    .HasConstraintName("OrderEmployees_FK_5");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderEmployees)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("OrderEmployees_FK");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.OrderEmployees)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("OrderEmployees_FK_7");

                entity.HasOne(d => d.TariffRate)
                    .WithMany(p => p.OrderEmployeeTariffRates)
                    .HasForeignKey(d => d.TariffRateId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("OrderEmployees_FK_4");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.Property(e => e.Title).IsRequired();
            });

            modelBuilder.Entity<SimpleDictionary>(entity =>
            {
                entity.Property(e => e.BusinessCode)
                    .HasMaxLength(50)
                    .HasColumnName("business_code");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .HasColumnName("code");

                entity.Property(e => e.EnName).HasColumnName("en_name");

                entity.Property(e => e.EntryDate)
                    .HasMaxLength(250)
                    .HasColumnName("entryDate");

                entity.Property(e => e.FromDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fromDate");

                entity.Property(e => e.KkName).HasColumnName("kk_name");

                entity.Property(e => e.ParentCode)
                    .HasMaxLength(50)
                    .HasColumnName("parent_code");

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.RuName).HasColumnName("ru_name");

                entity.Property(e => e.Title).IsRequired();

                entity.Property(e => e.ToDate)
                    .HasMaxLength(250)
                    .HasColumnName("toDate");

                entity.Property(e => e.TreeId)
                    .HasMaxLength(50)
                    .HasColumnName("tree_id");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Version)
                    .HasMaxLength(50)
                    .HasColumnName("version");

                entity.Property(e => e.Versions).HasColumnName("versions");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
