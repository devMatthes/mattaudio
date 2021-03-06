﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using mattaudio.Data;

namespace mattaudio.Migrations
{
    [DbContext(typeof(mattaudioContext))]
    [Migration("20200514112125_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("mattaudio.Models.Track", b =>
                {
                    b.Property<int>("TrackID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Artist")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("VideoID")
                        .HasColumnType("TEXT");

                    b.HasKey("TrackID");

                    b.ToTable("Track");
                });
#pragma warning restore 612, 618
        }
    }
}
