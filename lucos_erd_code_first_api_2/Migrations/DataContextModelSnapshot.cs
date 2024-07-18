﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using lucos_erd_code_first_api_2;

#nullable disable

namespace lucos_erd_code_first_api_2.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("lucos_erd_code_first_api_2.Game", b =>
                {
                    b.Property<int>("GameNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GameNumber"));

                    b.Property<DateOnly>("GameDate")
                        .HasColumnType("date");

                    b.Property<string>("OpeningPlayedId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("PlayerBId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlayerWId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GameNumber");

                    b.HasIndex("OpeningPlayedId");

                    b.HasIndex("PlayerBId");

                    b.HasIndex("PlayerWId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("lucos_erd_code_first_api_2.Opening", b =>
                {
                    b.Property<string>("OpeningCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("OpeningName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OpeningCode");

                    b.ToTable("Openings");
                });

            modelBuilder.Entity("lucos_erd_code_first_api_2.Player", b =>
                {
                    b.Property<Guid>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PlayerFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlayerLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlayerRating")
                        .HasColumnType("int");

                    b.HasKey("PlayerId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("lucos_erd_code_first_api_2.Game", b =>
                {
                    b.HasOne("lucos_erd_code_first_api_2.Opening", "OpeningPlayed")
                        .WithMany()
                        .HasForeignKey("OpeningPlayedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("lucos_erd_code_first_api_2.Player", "PlayerB")
                        .WithMany()
                        .HasForeignKey("PlayerBId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("lucos_erd_code_first_api_2.Player", "PlayerW")
                        .WithMany()
                        .HasForeignKey("PlayerWId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("OpeningPlayed");

                    b.Navigation("PlayerB");

                    b.Navigation("PlayerW");
                });
#pragma warning restore 612, 618
        }
    }
}
