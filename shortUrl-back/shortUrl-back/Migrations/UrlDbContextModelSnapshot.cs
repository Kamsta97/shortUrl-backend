﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using shortUrl_back.DataContext;

#nullable disable

namespace shortUrl_back.Migrations
{
    [DbContext(typeof(UrlDbContext))]
    partial class UrlDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("shortUrl_back.Models.Url", b =>
                {
                    b.Property<int>("UrlID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CreateDate")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("EntryCount")
                        .HasColumnType("int");

                    b.Property<string>("LongUrl")
                        .IsRequired()
                        .HasMaxLength(9999)
                        .HasColumnType("varchar(9999)");

                    b.Property<string>("ShortUrl")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("UrlID");

                    b.ToTable("Url");
                });
#pragma warning restore 612, 618
        }
    }
}
