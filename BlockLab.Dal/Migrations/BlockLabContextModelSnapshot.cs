// <auto-generated />
using System;
using BlockLab.Dal.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlockLab.Dal.Migrations
{
    [DbContext(typeof(BlockLabContext))]
    partial class BlockLabContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.1");

            modelBuilder.Entity("BlockLab.Domain.Entites.Research", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsNormal")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<string>("Note")
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<int>("ResearchObjectId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("BLOB");

                    b.Property<int>("TypeResearchId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<double>("Value")
                        .HasColumnType("REAL");

                    b.Property<int>("WorkShiftId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ResearchObjectId");

                    b.HasIndex("TypeResearchId");

                    b.HasIndex("WorkShiftId");

                    b.ToTable("Researches");
                });

            modelBuilder.Entity("BlockLab.Domain.Entites.ResearchObject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("BLOB");

                    b.HasKey("Id");

                    b.ToTable("ResearchObjects");
                });

            modelBuilder.Entity("BlockLab.Domain.Entites.TypeResearch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("BLOB");

                    b.Property<int>("TypeResult")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("TypeResearches");
                });

            modelBuilder.Entity("BlockLab.Domain.Entites.WorkShift", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("BLOB");

                    b.HasKey("Id");

                    b.ToTable("WorkShifts");
                });

            modelBuilder.Entity("BlockLab.Domain.Entites.BlockQualityResearch", b =>
                {
                    b.HasBaseType("BlockLab.Domain.Entites.Research");

                    b.Property<double>("Coefficient")
                        .HasColumnType("REAL");

                    b.Property<double>("DriedDensity")
                        .HasColumnType("REAL");

                    b.Property<double>("DriedWeight")
                        .HasColumnType("REAL");

                    b.Property<string>("Format")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<double>("Humidity")
                        .HasColumnType("REAL");

                    b.Property<double>("Load")
                        .HasColumnType("REAL");

                    b.Property<double>("RawDensity")
                        .HasColumnType("REAL");

                    b.Property<double>("RawWeight")
                        .HasColumnType("REAL");

                    b.Property<double>("SizeX")
                        .HasColumnType("REAL");

                    b.Property<double>("SizeY")
                        .HasColumnType("REAL");

                    b.Property<double>("SizeZ")
                        .HasColumnType("REAL");

                    b.Property<double>("Strength")
                        .HasColumnType("REAL");

                    b.Property<string>("Trademark")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<double>("Weight")
                        .HasColumnType("REAL");

                    b.ToTable("BlockQualityReearches");
                });

            modelBuilder.Entity("BlockLab.Domain.Entites.CementResearch", b =>
                {
                    b.HasBaseType("BlockLab.Domain.Entites.Research");

                    b.Property<double>("ActualKsh")
                        .HasColumnType("REAL");

                    b.Property<double>("ActualNsh")
                        .HasColumnType("REAL");

                    b.Property<double>("ActualVc")
                        .HasColumnType("REAL");

                    b.Property<string>("FromName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Party")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<double>("PassportKsh")
                        .HasColumnType("REAL");

                    b.Property<double>("PassportNsh")
                        .HasColumnType("REAL");

                    b.Property<double>("PassportVc")
                        .HasColumnType("REAL");

                    b.ToTable("CementResearch");
                });

            modelBuilder.Entity("BlockLab.Domain.Entites.HammerBinderResearch", b =>
                {
                    b.HasBaseType("BlockLab.Domain.Entites.Research");

                    b.Property<double>("Activity")
                        .HasColumnType("REAL");

                    b.Property<double>("Perfomance")
                        .HasColumnType("REAL");

                    b.Property<double>("Sieve0_2")
                        .HasColumnType("REAL");

                    b.Property<double>("Surface")
                        .HasColumnType("REAL");

                    b.ToTable("HammerBinderResearch");
                });

            modelBuilder.Entity("BlockLab.Domain.Entites.MudResearch", b =>
                {
                    b.HasBaseType("BlockLab.Domain.Entites.Research");

                    b.Property<double>("Density")
                        .HasColumnType("REAL");

                    b.Property<double>("Gypsum")
                        .HasColumnType("REAL");

                    b.Property<double>("Humidity")
                        .HasColumnType("REAL");

                    b.Property<double>("Sieve0_045")
                        .HasColumnType("REAL");

                    b.Property<double>("Sieve0_09")
                        .HasColumnType("REAL");

                    b.Property<double>("Sieve0_8")
                        .HasColumnType("REAL");

                    b.Property<double>("Surface")
                        .HasColumnType("REAL");

                    b.ToTable("MudReearches");
                });

            modelBuilder.Entity("BlockLab.Domain.Entites.Research", b =>
                {
                    b.HasOne("BlockLab.Domain.Entites.ResearchObject", "ResearchObject")
                        .WithMany("Researches")
                        .HasForeignKey("ResearchObjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlockLab.Domain.Entites.TypeResearch", "TypeResearch")
                        .WithMany("Researches")
                        .HasForeignKey("TypeResearchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlockLab.Domain.Entites.WorkShift", "WorkShift")
                        .WithMany("Researches")
                        .HasForeignKey("WorkShiftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ResearchObject");

                    b.Navigation("TypeResearch");

                    b.Navigation("WorkShift");
                });

            modelBuilder.Entity("BlockLab.Domain.Entites.BlockQualityResearch", b =>
                {
                    b.HasOne("BlockLab.Domain.Entites.Research", null)
                        .WithOne()
                        .HasForeignKey("BlockLab.Domain.Entites.BlockQualityResearch", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BlockLab.Domain.Entites.CementResearch", b =>
                {
                    b.HasOne("BlockLab.Domain.Entites.Research", null)
                        .WithOne()
                        .HasForeignKey("BlockLab.Domain.Entites.CementResearch", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BlockLab.Domain.Entites.HammerBinderResearch", b =>
                {
                    b.HasOne("BlockLab.Domain.Entites.Research", null)
                        .WithOne()
                        .HasForeignKey("BlockLab.Domain.Entites.HammerBinderResearch", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BlockLab.Domain.Entites.MudResearch", b =>
                {
                    b.HasOne("BlockLab.Domain.Entites.Research", null)
                        .WithOne()
                        .HasForeignKey("BlockLab.Domain.Entites.MudResearch", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BlockLab.Domain.Entites.ResearchObject", b =>
                {
                    b.Navigation("Researches");
                });

            modelBuilder.Entity("BlockLab.Domain.Entites.TypeResearch", b =>
                {
                    b.Navigation("Researches");
                });

            modelBuilder.Entity("BlockLab.Domain.Entites.WorkShift", b =>
                {
                    b.Navigation("Researches");
                });
#pragma warning restore 612, 618
        }
    }
}
