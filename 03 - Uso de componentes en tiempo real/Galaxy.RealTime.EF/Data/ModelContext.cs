using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Galaxy.RealTime.EF.Data
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alumno> Alumno { get; set; }
        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<Especialidad> Especialidad { get; set; }
        public virtual DbSet<Notas> Notas { get; set; }
        public virtual DbSet<Pagos> Pagos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseOracle("User Id=mblas;Password=123456;data source=192.168.1.21:1521/xe;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:DefaultSchema", "MBLAS");

            modelBuilder.Entity<Alumno>(entity =>
            {
                entity.HasKey(e => e.Idalumno)
                    .HasName("SYS_C008209");

                entity.ToTable("ALUMNO");

                entity.HasIndex(e => e.Idalumno)
                    .HasName("SYS_C008209")
                    .IsUnique();

                entity.Property(e => e.Idalumno)
                    .HasColumnName("IDALUMNO")
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Apealumno)
                    .IsRequired()
                    .HasColumnName("APEALUMNO")
                    .HasColumnType("VARCHAR2(30)");

                entity.Property(e => e.Idesp)
                    .HasColumnName("IDESP")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.Nomalumno)
                    .IsRequired()
                    .HasColumnName("NOMALUMNO")
                    .HasColumnType("VARCHAR2(30)");

                entity.Property(e => e.Proce)
                    .HasColumnName("PROCE")
                    .HasColumnType("CHAR(1)")
                    .HasDefaultValueSql("NULL");
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.Idcurso)
                    .HasName("SYS_C008212");

                entity.ToTable("CURSO");

                entity.HasIndex(e => e.Idcurso)
                    .HasName("SYS_C008212")
                    .IsUnique();

                entity.Property(e => e.Idcurso)
                    .HasColumnName("IDCURSO")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.Credito)
                    .HasColumnName("CREDITO")
                    .HasColumnType("NUMBER")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Nomcurso)
                    .IsRequired()
                    .HasColumnName("NOMCURSO")
                    .HasColumnType("VARCHAR2(35)");
            });

            modelBuilder.Entity<Especialidad>(entity =>
            {
                entity.HasKey(e => e.Idesp)
                    .HasName("SYS_C008221");

                entity.ToTable("ESPECIALIDAD");

                entity.HasIndex(e => e.Idesp)
                    .HasName("SYS_C008221")
                    .IsUnique();

                entity.Property(e => e.Idesp)
                    .HasColumnName("IDESP")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.Costo)
                    .HasColumnName("COSTO")
                    .HasColumnType("NUMBER(8,1)");

                entity.Property(e => e.Nomesp)
                    .IsRequired()
                    .HasColumnName("NOMESP")
                    .HasColumnType("VARCHAR2(30)");
            });

            modelBuilder.Entity<Notas>(entity =>
            {
                entity.HasKey(e => new { e.Idalumno, e.Idcurso })
                    .HasName("SYS_C008224");

                entity.ToTable("NOTAS");

                entity.HasIndex(e => new { e.Idalumno, e.Idcurso })
                    .HasName("SYS_C008224")
                    .IsUnique();

                entity.Property(e => e.Idalumno)
                    .HasColumnName("IDALUMNO")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.Idcurso)
                    .HasColumnName("IDCURSO")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.Exf)
                    .HasColumnName("EXF")
                    .HasColumnType("NUMBER")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Exp)
                    .HasColumnName("EXP")
                    .HasColumnType("NUMBER")
                    .HasDefaultValueSql("NULL");
            });

            modelBuilder.Entity<Pagos>(entity =>
            {
                entity.HasKey(e => new { e.Idalumno, e.Ciclo, e.Ncuota })
                    .HasName("SYS_C008217");

                entity.ToTable("PAGOS");

                entity.HasIndex(e => new { e.Idalumno, e.Ciclo, e.Ncuota })
                    .HasName("SYS_C008217")
                    .IsUnique();

                entity.Property(e => e.Idalumno)
                    .HasColumnName("IDALUMNO")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.Ciclo)
                    .HasColumnName("CICLO")
                    .HasColumnType("VARCHAR2(6)");

                entity.Property(e => e.Ncuota)
                    .HasColumnName("NCUOTA")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.Fecha)
                    .HasColumnName("FECHA")
                    .HasColumnType("DATE")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Monto)
                    .HasColumnName("MONTO")
                    .HasColumnType("NUMBER(12,2)");
            });

            modelBuilder.HasSequence("ALUMNO_SEQ");
        }
    }
}
