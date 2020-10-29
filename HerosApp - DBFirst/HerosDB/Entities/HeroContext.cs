using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace HerosDB.Entities
{
    public partial class HeroContext : DbContext
    {
        public HeroContext()
        {
        }

        public HeroContext(DbContextOptions<HeroContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Charactertype> Charactertype { get; set; }
        public virtual DbSet<Enemies> Enemies { get; set; }
        public virtual DbSet<PgStatStatements> PgStatStatements { get; set; }
        public virtual DbSet<Powers> Powers { get; set; }
        public virtual DbSet<Superpeople> Superpeople { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

                var connectionString = configuration.GetConnectionString("HeroDB");
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("btree_gin")
                .HasPostgresExtension("btree_gist")
                .HasPostgresExtension("citext")
                .HasPostgresExtension("cube")
                .HasPostgresExtension("dblink")
                .HasPostgresExtension("dict_int")
                .HasPostgresExtension("dict_xsyn")
                .HasPostgresExtension("earthdistance")
                .HasPostgresExtension("fuzzystrmatch")
                .HasPostgresExtension("hstore")
                .HasPostgresExtension("intarray")
                .HasPostgresExtension("ltree")
                .HasPostgresExtension("pg_stat_statements")
                .HasPostgresExtension("pg_trgm")
                .HasPostgresExtension("pgcrypto")
                .HasPostgresExtension("pgrowlocks")
                .HasPostgresExtension("pgstattuple")
                .HasPostgresExtension("tablefunc")
                .HasPostgresExtension("unaccent")
                .HasPostgresExtension("uuid-ossp")
                .HasPostgresExtension("xml2");

            modelBuilder.Entity<Charactertype>(entity =>
            {
                entity.ToTable("charactertype");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chartype)
                    .HasColumnName("chartype")
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<Enemies>(entity =>
            {
                entity.ToTable("enemies");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Heroid).HasColumnName("heroid");

                entity.Property(e => e.Villainid).HasColumnName("villainid");

                entity.HasOne(d => d.Hero)
                    .WithMany(p => p.EnemiesHero)
                    .HasForeignKey(d => d.Heroid)
                    .HasConstraintName("enemies_heroid_fkey");

                entity.HasOne(d => d.Villain)
                    .WithMany(p => p.EnemiesVillain)
                    .HasForeignKey(d => d.Villainid)
                    .HasConstraintName("enemies_villainid_fkey");
            });

            modelBuilder.Entity<PgStatStatements>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pg_stat_statements");

                entity.Property(e => e.BlkReadTime).HasColumnName("blk_read_time");

                entity.Property(e => e.BlkWriteTime).HasColumnName("blk_write_time");

                entity.Property(e => e.Calls).HasColumnName("calls");

                entity.Property(e => e.Dbid)
                    .HasColumnName("dbid")
                    .HasColumnType("oid");

                entity.Property(e => e.LocalBlksDirtied).HasColumnName("local_blks_dirtied");

                entity.Property(e => e.LocalBlksHit).HasColumnName("local_blks_hit");

                entity.Property(e => e.LocalBlksRead).HasColumnName("local_blks_read");

                entity.Property(e => e.LocalBlksWritten).HasColumnName("local_blks_written");

                entity.Property(e => e.MaxTime).HasColumnName("max_time");

                entity.Property(e => e.MeanTime).HasColumnName("mean_time");

                entity.Property(e => e.MinTime).HasColumnName("min_time");

                entity.Property(e => e.Query).HasColumnName("query");

                entity.Property(e => e.Queryid).HasColumnName("queryid");

                entity.Property(e => e.Rows).HasColumnName("rows");

                entity.Property(e => e.SharedBlksDirtied).HasColumnName("shared_blks_dirtied");

                entity.Property(e => e.SharedBlksHit).HasColumnName("shared_blks_hit");

                entity.Property(e => e.SharedBlksRead).HasColumnName("shared_blks_read");

                entity.Property(e => e.SharedBlksWritten).HasColumnName("shared_blks_written");

                entity.Property(e => e.StddevTime).HasColumnName("stddev_time");

                entity.Property(e => e.TempBlksRead).HasColumnName("temp_blks_read");

                entity.Property(e => e.TempBlksWritten).HasColumnName("temp_blks_written");

                entity.Property(e => e.TotalTime).HasColumnName("total_time");

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasColumnType("oid");
            });

            modelBuilder.Entity<Powers>(entity =>
            {
                entity.ToTable("powers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(20);

                entity.Property(e => e.Ownerid).HasColumnName("ownerid");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Powers)
                    .HasForeignKey(d => d.Ownerid)
                    .HasConstraintName("powers_ownerid_fkey");
            });

            modelBuilder.Entity<Superpeople>(entity =>
            {
                entity.ToTable("superpeople");

                entity.HasIndex(e => e.Workname)
                    .HasName("superpeople_workname_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chartype).HasColumnName("chartype");

                entity.Property(e => e.Hideout)
                    .IsRequired()
                    .HasColumnName("hideout")
                    .HasMaxLength(50);

                entity.Property(e => e.Realname)
                    .IsRequired()
                    .HasColumnName("realname")
                    .HasMaxLength(50);

                entity.Property(e => e.Workname)
                    .IsRequired()
                    .HasColumnName("workname")
                    .HasMaxLength(50);

                entity.HasOne(d => d.ChartypeNavigation)
                    .WithMany(p => p.Superpeople)
                    .HasForeignKey(d => d.Chartype)
                    .HasConstraintName("superpeople_chartype_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
