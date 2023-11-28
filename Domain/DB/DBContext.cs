using System;
using System.Collections.Generic;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.DB;

public partial class DBContext : DbContext
{
    public DBContext()
    {
    }

    public DBContext(DbContextOptions<DBContext> options): base(options)
    {
    }

    public virtual DbSet<Categorie> Categories { get; set; }

    public virtual DbSet<Evenement> Evenements { get; set; }

    public virtual DbSet<EvenementSponseur> EvenementSponseurs { get; set; }

    public virtual DbSet<Fichier> Fichiers { get; set; }

    public virtual DbSet<Lien> Liens { get; set; }

    public virtual DbSet<Participant> Participants { get; set; }

    public virtual DbSet<Pay> Pays { get; set; }

    public virtual DbSet<PublicCible> PublicCibles { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    public virtual DbSet<Speaker> Speakers { get; set; }

    public virtual DbSet<Sponseur> Sponseurs { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Ville> Villes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorie>(entity =>
        {
            entity.HasKey(e => e.IdCategorie).HasName("PK__Categori__A3C02A1C258C79F9");

            entity.ToTable("Categorie");

            entity.Property(e => e.IdCategorie).ValueGeneratedNever();
            entity.Property(e => e.IdEve).HasColumnName("idEve");
            entity.Property(e => e.NameCategorie)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEveNavigation).WithMany(p => p.Categories)
                .HasForeignKey(d => d.IdEve)
                .HasConstraintName("FK__Categorie__idEve__4222D4EF");
        });

        modelBuilder.Entity<Evenement>(entity =>
        {
            entity.HasKey(e => e.IdEve).HasName("PK__Evenemen__3F0AB95486AC6F06");

            entity.ToTable("Evenement");

            entity.Property(e => e.IdEve)
                .ValueGeneratedNever()
                .HasColumnName("idEve");
            entity.Property(e => e.AdressEve).HasMaxLength(100);
            entity.Property(e => e.DateDebut).HasColumnType("datetime");
            entity.Property(e => e.DateFin).HasColumnType("datetime");
            entity.Property(e => e.DescriptionEve).HasMaxLength(4000);
            entity.Property(e => e.IdVille).HasColumnName("idVille");
            entity.Property(e => e.NbrPart).HasColumnName("nbrPart");
            entity.Property(e => e.NbrPlace).HasColumnName("nbrPlace");
            entity.Property(e => e.NomEve).HasMaxLength(100);
            entity.Property(e => e.TypeEve)
                .HasMaxLength(100)
                .HasColumnName("typeEve");

            entity.HasOne(d => d.IdVilleNavigation).WithMany(p => p.Evenements)
                .HasForeignKey(d => d.IdVille)
                .HasConstraintName("FK__Evenement__idVil__2F10007B");
        });

        modelBuilder.Entity<EvenementSponseur>(entity =>
        {
            entity.HasKey(e => e.IdEveSpo).HasName("PK__Evenemen__225EA03A8BED6E6B");

            entity.ToTable("EvenementSponseur");

            entity.HasIndex(e => new { e.IdSponsor, e.IdEve }, "UC_EvenementSponseur").IsUnique();

            entity.Property(e => e.IdEveSpo)
                .ValueGeneratedNever()
                .HasColumnName("idEveSpo");
            entity.Property(e => e.IdEve).HasColumnName("idEve");
            entity.Property(e => e.IdSponsor).HasColumnName("idSponsor");

            entity.HasOne(d => d.IdEveNavigation).WithMany(p => p.EvenementSponseurs)
                .HasForeignKey(d => d.IdEve)
                .HasConstraintName("FK__Evenement__idEve__35BCFE0A");

            entity.HasOne(d => d.IdSponsorNavigation).WithMany(p => p.EvenementSponseurs)
                .HasForeignKey(d => d.IdSponsor)
                .HasConstraintName("FK__Evenement__idSpo__34C8D9D1");
        });

        modelBuilder.Entity<Fichier>(entity =>
        {
            entity.HasKey(e => e.FichierId).HasName("PK__Fichier__DF1B02143AE2F708");

            entity.ToTable("Fichier");

            entity.Property(e => e.FichierId).ValueGeneratedNever();
            entity.Property(e => e.FichierUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("FichierURL");
        });

        modelBuilder.Entity<Lien>(entity =>
        {
            entity.HasKey(e => e.IdLien).HasName("PK__Lien__31D8FFC7FD4000FC");

            entity.ToTable("Lien");

            entity.Property(e => e.IdLien).ValueGeneratedNever();
            entity.Property(e => e.LienType).HasMaxLength(40);
            entity.Property(e => e.Url)
                .HasMaxLength(500)
                .HasColumnName("url");

            entity.HasOne(d => d.Speaker).WithMany(p => p.Liens)
                .HasForeignKey(d => d.SpeakerId)
                .HasConstraintName("FK__Lien__SpeakerId__3C69FB99");
        });

        modelBuilder.Entity<Participant>(entity =>
        {
            entity.HasKey(e => e.PublicCibleId).HasName("PK__Particip__F3208B3395662D02");

            entity.ToTable("Participant");

            entity.Property(e => e.PublicCibleId).ValueGeneratedNever();
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdEve).HasColumnName("idEve");

            entity.HasOne(d => d.IdEveNavigation).WithMany(p => p.Participants)
                .HasForeignKey(d => d.IdEve)
                .HasConstraintName("FK__Participa__idEve__47DBAE45");
        });

        modelBuilder.Entity<Pay>(entity =>
        {
            entity.HasKey(e => e.IdPays).HasName("PK__Pays__BD257B670349C280");

            entity.Property(e => e.IdPays)
                .ValueGeneratedNever()
                .HasColumnName("idPays");
            entity.Property(e => e.NomPays)
                .HasMaxLength(40)
                .HasColumnName("nomPays");
        });

        modelBuilder.Entity<PublicCible>(entity =>
        {
            entity.HasKey(e => e.PublicCibleId).HasName("PK__PublicCi__1952B5DBB52ADBDB");

            entity.ToTable("PublicCible");

            entity.Property(e => e.PublicCibleId).ValueGeneratedNever();
            entity.Property(e => e.IdEve).HasColumnName("idEve");
            entity.Property(e => e.PublicCibleName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEveNavigation).WithMany(p => p.PublicCibles)
                .HasForeignKey(d => d.IdEve)
                .HasConstraintName("FK__PublicCib__idEve__3F466844");
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.HasKey(e => e.IdSession).HasName("PK__Session__A348337750F44FE5");

            entity.ToTable("Session");

            entity.Property(e => e.IdSession).ValueGeneratedNever();
            entity.Property(e => e.DateDebut).HasColumnType("datetime");
            entity.Property(e => e.DateFin).HasColumnType("datetime");
            entity.Property(e => e.IdEve).HasColumnName("idEve");
            entity.Property(e => e.Lieu)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEveNavigation).WithMany(p => p.Sessions)
                .HasForeignKey(d => d.IdEve)
                .HasConstraintName("FK__Session__idEve__44FF419A");
        });

        modelBuilder.Entity<Speaker>(entity =>
        {
            entity.HasKey(e => e.SpeakerId).HasName("PK__Speaker__79E7575969B85164");

            entity.ToTable("Speaker");

            entity.Property(e => e.SpeakerId).ValueGeneratedNever();
            entity.Property(e => e.Biography).IsUnicode(false);
            entity.Property(e => e.IdEve).HasColumnName("idEve");
            entity.Property(e => e.Mct).HasColumnName("MCT");
            entity.Property(e => e.Mvp).HasColumnName("MVP");

            entity.HasOne(d => d.Fichier).WithMany(p => p.Speakers)
                .HasForeignKey(d => d.FichierId)
                .HasConstraintName("FK__Speaker__Fichier__38996AB5");

            entity.HasOne(d => d.IdEveNavigation).WithMany(p => p.Speakers)
                .HasForeignKey(d => d.IdEve)
                .HasConstraintName("FK__Speaker__idEve__398D8EEE");
        });

        modelBuilder.Entity<Sponseur>(entity =>
        {
            entity.HasKey(e => e.IdSponsor).HasName("PK__Sponseur__2D5A6D8B9401211D");

            entity.ToTable("Sponseur");

            entity.Property(e => e.IdSponsor)
                .ValueGeneratedNever()
                .HasColumnName("idSponsor");
            entity.Property(e => e.ImageUrl).IsUnicode(false);
            entity.Property(e => e.NomSponseur)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__User__B7C926382F2CC60B");

            entity.ToTable("User");

            entity.Property(e => e.IdUser).ValueGeneratedNever();
            entity.Property(e => e.Email).HasMaxLength(80);
            entity.Property(e => e.FullName).HasMaxLength(40);
            entity.Property(e => e.MotPass).HasMaxLength(25);
        });

        modelBuilder.Entity<Ville>(entity =>
        {
            entity.HasKey(e => e.IdVille).HasName("PK__Ville__A33D0147774AF700");

            entity.ToTable("Ville");

            entity.Property(e => e.IdVille)
                .ValueGeneratedNever()
                .HasColumnName("idVille");
            entity.Property(e => e.IdPays).HasColumnName("idPays");
            entity.Property(e => e.NomVille)
                .HasMaxLength(40)
                .HasColumnName("nomVille");

            entity.HasOne(d => d.IdPaysNavigation).WithMany(p => p.Villes)
                .HasForeignKey(d => d.IdPays)
                .HasConstraintName("FK__Ville__idPays__2B3F6F97");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
