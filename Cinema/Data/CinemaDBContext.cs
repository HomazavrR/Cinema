using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Cinema.Models;

#nullable disable

namespace Cinema.Data
{
    public partial class CinemaDBContext : DbContext
    {
        public CinemaDBContext()
        {
        }

        public CinemaDBContext(DbContextOptions<CinemaDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Должности> Должностиs { get; set; }
        public virtual DbSet<Жанры> Жанрыs { get; set; }
        public virtual DbSet<Места> Местаs { get; set; }
        public virtual DbSet<Репертуар> Репертуарs { get; set; }
        public virtual DbSet<Сотрудники> Сотрудникиs { get; set; }
        public virtual DbSet<Фильмы> Фильмыs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
             //   optionsBuilder.UseSqlite("Data Source=C:\\Users\\HomazavrR\\Documents\\CinemaDB.db");
               optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Cinema");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Должности>(entity =>
            {
                entity.HasKey(e => e.КодДолжности);

                entity.ToTable("Должности");

                entity.Property(e => e.КодДолжности)
                    .HasColumnType("INT")
                    .ValueGeneratedNever()
                    .HasColumnName("Код_должности");

                entity.Property(e => e.НаименованиеДолжности)
                    .IsRequired()
                    .HasColumnType("VARCHAR(50)")
                    .HasColumnName("Наименование_должности");

                entity.Property(e => e.Обязанности)
                    .IsRequired()
                    .HasColumnType("VARCHAR(50)");

                entity.Property(e => e.Оклад).HasColumnType("FLOAT");

                entity.Property(e => e.Требования)
                    .IsRequired()
                    .HasColumnType("VARCHAR(50)");
            });

            modelBuilder.Entity<Жанры>(entity =>
            {
                entity.HasKey(e => e.КодЖанра);

                entity.ToTable("Жанры");

                entity.Property(e => e.КодЖанра)
                    .HasColumnType("INT")
                    .ValueGeneratedNever()
                    .HasColumnName("Код_жанра");

                entity.Property(e => e.Наименование)
                    .IsRequired()
                    .HasColumnType("VARCHAR(50)");

                entity.Property(e => e.Описание)
                    .IsRequired()
                    .HasColumnType("VARCHAR(100)");
            });

            modelBuilder.Entity<Места>(entity =>
            {
                entity.HasKey(e => e.НомерМеста);

                entity.ToTable("Места");

                entity.Property(e => e.НомерМеста)
                    .HasColumnType("INT")
                    .ValueGeneratedNever()
                    .HasColumnName("Номер_места");

                entity.Property(e => e.Занятость)
                    .IsRequired()
                    .HasColumnType("CHAR(1)");

                entity.Property(e => e.КодСотрудника)
                    .HasColumnType("INT")
                    .HasColumnName("Код_сотрудника");

                entity.HasOne(d => d.КодСотрудникаNavigation)
                    .WithMany(p => p.Местаs)
                    .HasForeignKey(d => d.КодСотрудника)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Репертуар>(entity =>
            {
                entity.HasKey(e => e.КодСеанса);

                entity.ToTable("Репертуар");

                entity.Property(e => e.КодСеанса)
                    .HasColumnType("INT")
                    .ValueGeneratedNever()
                    .HasColumnName("Код_сеанса");

                entity.Property(e => e.ВремяНачала)
                    .IsRequired()
                    .HasColumnType("DATE")
                    .HasColumnName("Время_начала");

                entity.Property(e => e.ВремяОкончания)
                    .IsRequired()
                    .HasColumnType("DATE")
                    .HasColumnName("Время_окончания");

                entity.Property(e => e.Дата)
                    .IsRequired()
                    .HasColumnType("DATE");

                entity.Property(e => e.ЦенаБилета)
                    .HasColumnType("FLOAT")
                    .HasColumnName("Цена_билета");
            });

            modelBuilder.Entity<Сотрудники>(entity =>
            {
                entity.HasKey(e => e.КодСотрудника);

                entity.ToTable("Сотрудники");

                entity.Property(e => e.КодСотрудника)
                    .HasColumnType("INT")
                    .ValueGeneratedNever()
                    .HasColumnName("Код_сотрудника");

                entity.Property(e => e.Адрес)
                    .IsRequired()
                    .HasColumnType("VARCHAR(50)");

                entity.Property(e => e.Возраст).HasColumnType("INT");

                entity.Property(e => e.КодДолжности)
                    .HasColumnType("INT")
                    .HasColumnName("Код_должности");

                entity.Property(e => e.ПаспортныеДанные)
                    .IsRequired()
                    .HasColumnType("VARCHAR(20)")
                    .HasColumnName("Паспортные_данные");

                entity.Property(e => e.Пол)
                    .IsRequired()
                    .HasColumnType("CHAR(3)");

                entity.Property(e => e.Телефон)
                    .IsRequired()
                    .HasColumnType("VARCHAR(20)");

                entity.Property(e => e.Фио)
                    .IsRequired()
                    .HasColumnType("VARCHAR(50)");

                entity.HasOne(d => d.КодДолжностиNavigation)
                    .WithMany(p => p.Сотрудникиs)
                    .HasForeignKey(d => d.КодДолжности)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Фильмы>(entity =>
            {
                entity.HasKey(e => e.КодФильма);

                entity.ToTable("Фильмы");

                entity.Property(e => e.КодФильма)
                    .HasColumnType("INT")
                    .ValueGeneratedNever()
                    .HasColumnName("Код_фильма");

                entity.Property(e => e.Актеры)
                    .IsRequired()
                    .HasColumnType("VARCHAR(50)");

                entity.Property(e => e.ВозрастныеОграничения)
                    .IsRequired()
                    .HasColumnType("CHAR(3)")
                    .HasColumnName("Возрастные_ограничения");

                entity.Property(e => e.Длительность).HasColumnType("FLOAT");

                entity.Property(e => e.КодЖанра)
                    .HasColumnType("INT")
                    .HasColumnName("Код_жанра");

                entity.Property(e => e.КодСеанса)
                    .HasColumnType("INT")
                    .HasColumnName("Код_сеанса");

                entity.Property(e => e.Наименование)
                    .IsRequired()
                    .HasColumnType("VARCHAR(50)");

                entity.Property(e => e.НомерМеста)
                    .HasColumnType("INT")
                    .HasColumnName("Номер_места");

                entity.Property(e => e.Описание)
                    .IsRequired()
                    .HasColumnType("VARCHAR(100)");

                entity.Property(e => e.СтранаПроизводителя)
                    .IsRequired()
                    .HasColumnType("VARCHAR(50)")
                    .HasColumnName("Страна_производителя");

                entity.Property(e => e.ФирмаПроизводителя)
                    .IsRequired()
                    .HasColumnType("VARCHAR(50)")
                    .HasColumnName("Фирма_производителя");

                entity.HasOne(d => d.КодЖанраNavigation)
                    .WithMany(p => p.Фильмыs)
                    .HasForeignKey(d => d.КодЖанра)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.КодСеансаNavigation)
                    .WithMany(p => p.Фильмыs)
                    .HasForeignKey(d => d.КодСеанса)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.НомерМестаNavigation)
                    .WithMany(p => p.Фильмыs)
                    .HasForeignKey(d => d.НомерМеста)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
