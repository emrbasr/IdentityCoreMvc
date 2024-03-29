﻿// <auto-generated />
using System;
using Mersin.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Mersin.Api.Migrations
{
    [DbContext(typeof(MernisContext))]
    partial class MernisContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Mersin.Api.Entities.Citizen", b =>
                {
                    b.Property<long>("Uid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("uid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Uid"));

                    b.Property<string>("AddressCity")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("address_city");

                    b.Property<string>("AddressDistrict")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("address_district");

                    b.Property<string>("AddressNeighborhood")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("address_neighborhood");

                    b.Property<string>("BirthCity")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("birth_city");

                    b.Property<string>("DateOfBirth")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("date_of_birth");

                    b.Property<string>("DoorOrEntranceNumber")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("door_or_entrance_number");

                    b.Property<string>("FatherFirst")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("father_first");

                    b.Property<string>("First")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("first");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("character varying(1)")
                        .HasColumnName("gender");

                    b.Property<string>("IdRegistrationCity")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("id_registration_city");

                    b.Property<string>("IdRegistrationDistrict")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("id_registration_district");

                    b.Property<string>("Last")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("last");

                    b.Property<string>("Misc")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("misc");

                    b.Property<string>("MotherFirst")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("mother_first");

                    b.Property<string>("NationalIdentifier")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("national_identifier");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("street_address");

                    b.HasKey("Uid")
                        .HasName("citizen_pkey");

                    b.HasIndex(new[] { "IdRegistrationCity" }, "citizen_id_registration_city_idx");

                    b.HasIndex(new[] { "Last" }, "citizen_last_idx");

                    b.ToTable("citizen", (string)null);
                });

            modelBuilder.Entity("Mersin.Api.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Mersin.Api.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("text");

                    b.Property<DateTime?>("RefreshTokenEndTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Mersin.Api.Entities.UserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Mersin.Api.Entities.UserRole", b =>
                {
                    b.HasOne("Mersin.Api.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mersin.Api.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Mersin.Api.Entities.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Mersin.Api.Entities.User", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
