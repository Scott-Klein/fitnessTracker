﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using fitnessTracker.Data;

namespace fitnessTracker.Data.Migrations
{
    [DbContext(typeof(FitnessTrackerDbContext))]
    [Migration("20200210050622_createDatabase")]
    partial class createDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("fitnessTracker.core.DiscreteExercisePlan", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileEmail")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("id");

                    b.HasIndex("ProfileEmail");

                    b.ToTable("DiscreteExercisePlan");
                });

            modelBuilder.Entity("fitnessTracker.core.FitnessPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<int>("Pushups")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FitnessPlans");
                });

            modelBuilder.Entity("fitnessTracker.core.Profile", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Email");

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("fitnessTracker.core.DiscreteExercisePlan", b =>
                {
                    b.HasOne("fitnessTracker.core.Profile", null)
                        .WithMany("DiscreteExercisePlans")
                        .HasForeignKey("ProfileEmail");
                });
#pragma warning restore 612, 618
        }
    }
}
