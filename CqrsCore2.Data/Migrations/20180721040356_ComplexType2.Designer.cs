﻿// <auto-generated />
using System;
using CqrsCore2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CqrsCore2.Data.Migrations
{
    [DbContext(typeof(CqrsCore2Context))]
    [Migration("20180721040356_ComplexType2")]
    partial class ComplexType2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CqrsCore2.Domain.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("CqrsCore2.Domain.Customer", b =>
                {
                    b.OwnsOne("CqrsCore2.Domain.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid?>("CustomerId");

                            b1.Property<string>("EmailAdress")
                                .IsRequired()
                                .HasColumnName("Email")
                                .HasMaxLength(150);

                            b1.ToTable("Customers");

                            b1.HasOne("CqrsCore2.Domain.Customer")
                                .WithOne("Email")
                                .HasForeignKey("CqrsCore2.Domain.ValueObjects.Email", "CustomerId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("CqrsCore2.Domain.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<Guid?>("CustomerId");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnName("FirstName")
                                .HasMaxLength(40);

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnName("LastName")
                                .HasMaxLength(80);

                            b1.ToTable("Customers");

                            b1.HasOne("CqrsCore2.Domain.Customer")
                                .WithOne("Name")
                                .HasForeignKey("CqrsCore2.Domain.ValueObjects.Name", "CustomerId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
