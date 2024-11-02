using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DevHelper.Data.Models;

public partial class DBdevhelperContext : DbContext
{
    public DBdevhelperContext()
    {
    }

    public DBdevhelperContext(DbContextOptions<DBdevhelperContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ArquivoProblema> ArquivoProblemas { get; set; }

    public virtual DbSet<ArquivoSolucao> ArquivoSolucaos { get; set; }

    public virtual DbSet<Problema> Problemas { get; set; }

    public virtual DbSet<ProblemaUsuario> ProblemaUsuarios { get; set; }

    public virtual DbSet<Solucao> Solucaos { get; set; }

    public virtual DbSet<SolucaoUsuario> SolucaoUsuarios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(optionsBuilder.IsConfigured) optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=DevHelper;Trusted_Connection=True;TrustServerCertificate=True");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ArquivoProblema>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ArquivoP__3213E83FA7AA804E");

            entity.ToTable("ArquivoProblema");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Referencia).HasColumnType("text");

            entity.HasOne(d => d.Problema).WithMany(p => p.ArquivoProblemas)
                .HasForeignKey(d => d.ProblemaId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__ArquivoPr__Probl__5070F446");
        });

        modelBuilder.Entity<ArquivoSolucao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ArquivoS__3213E83F5FAFF597");

            entity.ToTable("ArquivoSolucao");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Referencia).HasColumnType("text");

            entity.HasOne(d => d.Solucao).WithMany(p => p.ArquivoSolucaos)
                .HasForeignKey(d => d.SolucaoId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__ArquivoSo__Soluc__534D60F1");
        });

        modelBuilder.Entity<Problema>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Problema__3213E83F48C35DB4");

            entity.ToTable("Problema");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Descricao).HasColumnType("text");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ProblemaUsuario>(entity =>
        {
            entity.HasKey(e => new { e.UsuarioId, e.ProblemaId }).HasName("PK__Problema__DFA522FE143779A1");

            entity.ToTable("ProblemaUsuario");

            entity.Property(e => e.DataEnvio).HasColumnType("datetime");

            entity.HasOne(d => d.Problema).WithMany(p => p.ProblemaUsuarios)
                .HasForeignKey(d => d.ProblemaId)
                .HasConstraintName("FK__ProblemaU__Probl__571DF1D5");

            entity.HasOne(d => d.Usuario).WithMany(p => p.ProblemaUsuarios)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__ProblemaU__Usuar__5629CD9C");
        });

        modelBuilder.Entity<Solucao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Solucao__3213E83F6F6075EE");

            entity.ToTable("Solucao");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Descricao).HasColumnType("text");
        });

        modelBuilder.Entity<SolucaoUsuario>(entity =>
        {
            entity.HasKey(e => new { e.UsuarioId, e.SolucaoId }).HasName("PK__SolucaoU__7DA12207C3B7D9DB");

            entity.ToTable("SolucaoUsuario");

            entity.Property(e => e.DataEnvio).HasColumnType("datetime");

            entity.HasOne(d => d.Solucao).WithMany(p => p.SolucaoUsuarios)
                .HasForeignKey(d => d.SolucaoId)
                .HasConstraintName("FK__SolucaoUs__Soluc__5AEE82B9");

            entity.HasOne(d => d.Usuario).WithMany(p => p.SolucaoUsuarios)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__SolucaoUs__Usuar__59FA5E80");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3213E83F23A06CF9");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Email, "UQ__Usuario__A9D10534828C1E21").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Biografia).HasColumnType("text");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Senha)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
