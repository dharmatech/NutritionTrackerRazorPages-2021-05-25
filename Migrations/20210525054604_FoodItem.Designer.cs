﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NutritionTrackerRazorPages.Data;

namespace NutritionTrackerRazorPages.Migrations
{
    [DbContext(typeof(NutritionTrackerContext))]
    [Migration("20210525054604_FoodItem")]
    partial class FoodItem
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("NutritionTrackerRazorPages.Models.FoodCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("FoodCategory");
                });

            modelBuilder.Entity("NutritionTrackerRazorPages.Models.FoodItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Calories")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Fat")
                        .HasColumnType("TEXT");

                    b.Property<int>("FoodCategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("ServingSize")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FoodCategoryId");

                    b.ToTable("FoodItem");
                });

            modelBuilder.Entity("NutritionTrackerRazorPages.Models.FoodItem", b =>
                {
                    b.HasOne("NutritionTrackerRazorPages.Models.FoodCategory", "FoodCategory")
                        .WithMany()
                        .HasForeignKey("FoodCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FoodCategory");
                });
#pragma warning restore 612, 618
        }
    }
}
