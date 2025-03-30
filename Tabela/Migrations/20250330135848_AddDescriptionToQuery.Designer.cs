﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tabela;

#nullable disable

namespace Tabela.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250330135848_AddDescriptionToQuery")]
    partial class AddDescriptionToQuery
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Tabela.Models.Domains.Query", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Counter")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageFileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Radio")
                        .HasColumnType("bit");

                    b.Property<int>("TemplateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TemplateId");

                    b.ToTable("Queries");
                });

            modelBuilder.Entity("Tabela.Models.Domains.Template", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Templates");
                });

            modelBuilder.Entity("Tabela.Models.Domains.Query", b =>
                {
                    b.HasOne("Tabela.Models.Domains.Template", null)
                        .WithMany("Queries")
                        .HasForeignKey("TemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tabela.Models.Domains.Template", b =>
                {
                    b.Navigation("Queries");
                });
#pragma warning restore 612, 618
        }
    }
}
