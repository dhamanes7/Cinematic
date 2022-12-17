﻿// <auto-generated />
using System;
using Cinematic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cinematic.Migrations
{
    [DbContext(typeof(Data))]
    [Migration("20221216191548_CreateDb")]
    partial class CreateDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("Cinematic.Models.Movie", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("posterImageId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("releaseDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("posterImageId");

                    b.ToTable("Movie");
                });

            modelBuilder.Entity("Cinematic.Models.PosterImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("url")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("PosterImage");
                });

            modelBuilder.Entity("Cinematic.Models.Movie", b =>
                {
                    b.HasOne("Cinematic.Models.PosterImage", "posterImage")
                        .WithMany()
                        .HasForeignKey("posterImageId");

                    b.Navigation("posterImage");
                });
#pragma warning restore 612, 618
        }
    }
}