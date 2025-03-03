﻿// <auto-generated />
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.1");

            modelBuilder.Entity("Domain.Brand", b =>
                {
                    b.Property<int>("BrandID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("BrandID");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("Domain.Faction", b =>
                {
                    b.Property<int>("FactionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FactionDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FactionName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("FactionID");

                    b.ToTable("Factions");
                });

            modelBuilder.Entity("Domain.Model", b =>
                {
                    b.Property<int>("ModelID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("FactionID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("ModelQuantity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StateID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ModelID");

                    b.HasIndex("FactionID");

                    b.HasIndex("StateID");

                    b.HasIndex("UserID");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("Domain.ModelPaint", b =>
                {
                    b.Property<int>("ModelID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PaintID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ModelPaintID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UsageType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ModelID", "PaintID");

                    b.HasIndex("PaintID");

                    b.ToTable("ModelPaints");
                });

            modelBuilder.Entity("Domain.Paint", b =>
                {
                    b.Property<int>("PaintID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BrandID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("HexCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PaintName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("PaintQuantity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PaintTypeID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserID")
                        .HasColumnType("INTEGER");

                    b.HasKey("PaintID");

                    b.HasIndex("BrandID");

                    b.HasIndex("PaintTypeID");

                    b.HasIndex("UserID");

                    b.ToTable("Paints");
                });

            modelBuilder.Entity("Domain.PaintType", b =>
                {
                    b.Property<int>("PaintTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("TypeDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("PaintTypeID");

                    b.ToTable("PaintTypes");
                });

            modelBuilder.Entity("Domain.State", b =>
                {
                    b.Property<int>("StateID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("StateDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("StateID");

                    b.ToTable("States");
                });

            modelBuilder.Entity("Domain.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Model", b =>
                {
                    b.HasOne("Domain.Faction", "Faction")
                        .WithMany("Models")
                        .HasForeignKey("FactionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.State", "State")
                        .WithMany("Models")
                        .HasForeignKey("StateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.User", "User")
                        .WithMany("Models")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faction");

                    b.Navigation("State");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.ModelPaint", b =>
                {
                    b.HasOne("Domain.Model", "Model")
                        .WithMany("ModelPaints")
                        .HasForeignKey("ModelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Paint", "Paint")
                        .WithMany("ModelPaints")
                        .HasForeignKey("PaintID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Model");

                    b.Navigation("Paint");
                });

            modelBuilder.Entity("Domain.Paint", b =>
                {
                    b.HasOne("Domain.Brand", "Brand")
                        .WithMany("Paints")
                        .HasForeignKey("BrandID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.PaintType", "PaintType")
                        .WithMany("Paints")
                        .HasForeignKey("PaintTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.User", "User")
                        .WithMany("Paints")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("PaintType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Brand", b =>
                {
                    b.Navigation("Paints");
                });

            modelBuilder.Entity("Domain.Faction", b =>
                {
                    b.Navigation("Models");
                });

            modelBuilder.Entity("Domain.Model", b =>
                {
                    b.Navigation("ModelPaints");
                });

            modelBuilder.Entity("Domain.Paint", b =>
                {
                    b.Navigation("ModelPaints");
                });

            modelBuilder.Entity("Domain.PaintType", b =>
                {
                    b.Navigation("Paints");
                });

            modelBuilder.Entity("Domain.State", b =>
                {
                    b.Navigation("Models");
                });

            modelBuilder.Entity("Domain.User", b =>
                {
                    b.Navigation("Models");

                    b.Navigation("Paints");
                });
#pragma warning restore 612, 618
        }
    }
}
