﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TryWebApi.Data;

namespace TryWebApi.Migrations
{
    [DbContext(typeof(TryWebApiContext))]
    [Migration("20191108092034_NewIdentityInService")]
    partial class NewIdentityInService
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TryWebApi.Models.Service", b =>
                {
                    b.Property<int>("ServiceID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Cost");

                    b.Property<string>("ServiceName");

                    b.Property<int?>("UsersID");

                    b.HasKey("ServiceID");

                    b.HasIndex("UsersID");

                    b.ToTable("GetServices");
                });

            modelBuilder.Entity("TryWebApi.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<DateTime>("JoinDate");

                    b.Property<string>("UserName");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TryWebApi.Models.Service", b =>
                {
                    b.HasOne("TryWebApi.Models.User", "Users")
                        .WithMany("Services")
                        .HasForeignKey("UsersID");
                });
#pragma warning restore 612, 618
        }
    }
}
