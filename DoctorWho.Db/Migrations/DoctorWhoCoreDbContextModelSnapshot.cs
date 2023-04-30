﻿// <auto-generated />
using System;
using DoctorWho.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    [DbContext(typeof(DoctorWhoCoreDbContext))]
    partial class DoctorWhoCoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DoctorWho.Db.DbFunctions.FnCompanions", b =>
                {
                    b.Property<string>("companions")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("FnCompanions", t => t.ExcludeFromMigrations());
                });

            modelBuilder.Entity("DoctorWho.Db.DbFunctions.FnEnemies", b =>
                {
                    b.Property<string>("Enemies")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("FnEnemies", t => t.ExcludeFromMigrations());
                });

            modelBuilder.Entity("DoctorWho.Db.DbFunctions.spTopThreeEpisodeCompanions", b =>
                {
                    b.Property<int?>("CompanionsCount")
                        .HasColumnType("int");

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("spTopThreeEpisodeCompanions", t => t.ExcludeFromMigrations());

                    b.ToSqlQuery("EXEC spTopThreeEpisodesCompanions");
                });

            modelBuilder.Entity("DoctorWho.Db.DbFunctions.spTopThreeEpisodeEnemies", b =>
                {
                    b.Property<int?>("EnemiesCount")
                        .HasColumnType("int");

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("spTopThreeEpisodeEnemies", t => t.ExcludeFromMigrations());

                    b.ToSqlQuery("EXEC spTopThreeEpisodesEnemies");
                });

            modelBuilder.Entity("DoctorWho.Db.DbViews.ViewEpisodes", b =>
                {
                    b.Property<int?>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("AuthorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Companions")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CompanionName");

                    b.Property<int?>("DoctorId")
                        .HasColumnType("int");

                    b.Property<string>("DoctorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Enemies")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("EnemiesName");

                    b.Property<DateTime?>("EpisodDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EpisodNumber")
                        .HasColumnType("int");

                    b.Property<string>("EpisodType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EpisodeId")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SeriesNumber")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.ToView("viewEpisodes");

                    b.HasAnnotation("Relational:IsTableExcludedFromMigrations", true);
                });

            modelBuilder.Entity("DoctorWho.Db.Models.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthorId"), 1L, 1);

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            AuthorId = 1,
                            AuthorName = "Minato"
                        },
                        new
                        {
                            AuthorId = 2,
                            AuthorName = "Minato"
                        },
                        new
                        {
                            AuthorId = 3,
                            AuthorName = "Minato"
                        },
                        new
                        {
                            AuthorId = 4,
                            AuthorName = "Jiraya"
                        },
                        new
                        {
                            AuthorId = 5,
                            AuthorName = "Tsunadi"
                        });
                });

            modelBuilder.Entity("DoctorWho.Db.Models.Companion", b =>
                {
                    b.Property<int>("CompanionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompanionId"), 1L, 1);

                    b.Property<string>("CompanionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WhoPlayed")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanionId");

                    b.ToTable("Companions");

                    b.HasData(
                        new
                        {
                            CompanionId = 1,
                            CompanionName = "c1",
                            WhoPlayed = "p1"
                        },
                        new
                        {
                            CompanionId = 2,
                            CompanionName = "c2",
                            WhoPlayed = "p2"
                        },
                        new
                        {
                            CompanionId = 3,
                            CompanionName = "c3",
                            WhoPlayed = "p3"
                        },
                        new
                        {
                            CompanionId = 4,
                            CompanionName = "c4",
                            WhoPlayed = "p4"
                        },
                        new
                        {
                            CompanionId = 5,
                            CompanionName = "c5",
                            WhoPlayed = "p5"
                        });
                });

            modelBuilder.Entity("DoctorWho.Db.Models.CompanionEpisode", b =>
                {
                    b.Property<int>("CompanionId")
                        .HasColumnType("int")
                        .HasColumnName("CompanionsCompanionId");

                    b.Property<int>("EpisodeId")
                        .HasColumnType("int")
                        .HasColumnName("EpisodesEpisodeId");

                    b.HasKey("CompanionId", "EpisodeId");

                    b.HasIndex("EpisodeId");

                    b.ToTable("CompanionEpisode");

                    b.HasData(
                        new
                        {
                            CompanionId = 1,
                            EpisodeId = 4
                        },
                        new
                        {
                            CompanionId = 2,
                            EpisodeId = 5
                        },
                        new
                        {
                            CompanionId = 3,
                            EpisodeId = 4
                        },
                        new
                        {
                            CompanionId = 4,
                            EpisodeId = 1
                        },
                        new
                        {
                            CompanionId = 5,
                            EpisodeId = 5
                        });
                });

            modelBuilder.Entity("DoctorWho.Db.Models.Doctor", b =>
                {
                    b.Property<int>("DoctorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DoctorId"), 1L, 1);

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DoctorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DoctorNumber")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FirstEpisodDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastEpisodDate")
                        .HasColumnType("datetime2");

                    b.HasKey("DoctorId");

                    b.ToTable("Doctors");

                    b.HasData(
                        new
                        {
                            DoctorId = 1,
                            BirthDate = new DateTime(2000, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorName = "Minato",
                            DoctorNumber = 564841,
                            FirstEpisodDate = new DateTime(2011, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastEpisodDate = new DateTime(2020, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            DoctorId = 2,
                            BirthDate = new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorName = "demon",
                            DoctorNumber = 51654,
                            FirstEpisodDate = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastEpisodDate = new DateTime(2022, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            DoctorId = 3,
                            BirthDate = new DateTime(2005, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorName = "pain",
                            DoctorNumber = 5154,
                            FirstEpisodDate = new DateTime(2014, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastEpisodDate = new DateTime(2020, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            DoctorId = 4,
                            BirthDate = new DateTime(2006, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorName = "kakashi",
                            DoctorNumber = 2,
                            FirstEpisodDate = new DateTime(2013, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastEpisodDate = new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            DoctorId = 5,
                            BirthDate = new DateTime(2008, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorName = "shikamaro",
                            DoctorNumber = 3,
                            FirstEpisodDate = new DateTime(2012, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastEpisodDate = new DateTime(2020, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("DoctorWho.Db.Models.Enemy", b =>
                {
                    b.Property<int>("EnemyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnemyId"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnemyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EnemyId");

                    b.ToTable("Enemies");

                    b.HasData(
                        new
                        {
                            EnemyId = 1,
                            Description = "destroy the word",
                            EnemyName = "pain"
                        },
                        new
                        {
                            EnemyId = 2,
                            Description = "waking madara up",
                            EnemyName = "obito"
                        },
                        new
                        {
                            EnemyId = 3,
                            Description = "tsokoyome",
                            EnemyName = "Madara"
                        },
                        new
                        {
                            EnemyId = 4,
                            Description = "eat the forbidden fruit",
                            EnemyName = "Kaguya"
                        },
                        new
                        {
                            EnemyId = 5,
                            Description = "destroy Naruto anime",
                            EnemyName = "Boruto"
                        });
                });

            modelBuilder.Entity("DoctorWho.Db.Models.EnemyEpisode", b =>
                {
                    b.Property<int>("EnemyId")
                        .HasColumnType("int")
                        .HasColumnName("EnemiesEnemyId");

                    b.Property<int>("EpisodeId")
                        .HasColumnType("int")
                        .HasColumnName("EpisodesEpisodeId");

                    b.HasKey("EnemyId", "EpisodeId");

                    b.HasIndex("EpisodeId");

                    b.ToTable("EnemyEpisode");

                    b.HasData(
                        new
                        {
                            EnemyId = 1,
                            EpisodeId = 2
                        },
                        new
                        {
                            EnemyId = 3,
                            EpisodeId = 4
                        },
                        new
                        {
                            EnemyId = 2,
                            EpisodeId = 4
                        },
                        new
                        {
                            EnemyId = 4,
                            EpisodeId = 1
                        },
                        new
                        {
                            EnemyId = 5,
                            EpisodeId = 5
                        });
                });

            modelBuilder.Entity("DoctorWho.Db.Models.Episode", b =>
                {
                    b.Property<int>("EpisodeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EpisodeId"), 1L, 1);

                    b.Property<int?>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int?>("DoctorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EpisodDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EpisodNumber")
                        .HasColumnType("int");

                    b.Property<string>("EpisodType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SeriesNumber")
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EpisodeId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("DoctorId");

                    b.ToTable("Episodes");

                    b.HasData(
                        new
                        {
                            EpisodeId = 1,
                            AuthorId = 1,
                            DoctorId = 1,
                            EpisodDate = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EpisodNumber = 1,
                            EpisodType = "a",
                            Notes = "ddd",
                            SeriesNumber = "2",
                            Title = "vv"
                        },
                        new
                        {
                            EpisodeId = 2,
                            AuthorId = 3,
                            DoctorId = 2,
                            EpisodDate = new DateTime(2030, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EpisodNumber = 3,
                            EpisodType = "b",
                            Notes = "aaa",
                            SeriesNumber = "1",
                            Title = "vva"
                        },
                        new
                        {
                            EpisodeId = 3,
                            AuthorId = 2,
                            DoctorId = 5,
                            EpisodDate = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EpisodNumber = 2,
                            EpisodType = "c",
                            Notes = "fdsfds",
                            SeriesNumber = "3",
                            Title = "va"
                        },
                        new
                        {
                            EpisodeId = 4,
                            AuthorId = 5,
                            DoctorId = 3,
                            EpisodDate = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EpisodNumber = 5,
                            EpisodType = "d",
                            Notes = " ",
                            SeriesNumber = "4",
                            Title = "aavv"
                        },
                        new
                        {
                            EpisodeId = 5,
                            AuthorId = 4,
                            DoctorId = 4,
                            EpisodDate = new DateTime(2005, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EpisodNumber = 4,
                            EpisodType = "f",
                            Notes = "dsfdsf",
                            SeriesNumber = "5",
                            Title = "ddas"
                        });
                });

            modelBuilder.Entity("DoctorWho.Db.Models.CompanionEpisode", b =>
                {
                    b.HasOne("DoctorWho.Db.Models.Companion", null)
                        .WithMany()
                        .HasForeignKey("CompanionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoctorWho.Db.Models.Episode", null)
                        .WithMany()
                        .HasForeignKey("EpisodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DoctorWho.Db.Models.EnemyEpisode", b =>
                {
                    b.HasOne("DoctorWho.Db.Models.Enemy", null)
                        .WithMany()
                        .HasForeignKey("EnemyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoctorWho.Db.Models.Episode", null)
                        .WithMany()
                        .HasForeignKey("EpisodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DoctorWho.Db.Models.Episode", b =>
                {
                    b.HasOne("DoctorWho.Db.Models.Author", "Author")
                        .WithMany("Episodes")
                        .HasForeignKey("AuthorId");

                    b.HasOne("DoctorWho.Db.Models.Doctor", "Doctor")
                        .WithMany("Episodes")
                        .HasForeignKey("DoctorId");

                    b.Navigation("Author");

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("DoctorWho.Db.Models.Author", b =>
                {
                    b.Navigation("Episodes");
                });

            modelBuilder.Entity("DoctorWho.Db.Models.Doctor", b =>
                {
                    b.Navigation("Episodes");
                });
#pragma warning restore 612, 618
        }
    }
}
