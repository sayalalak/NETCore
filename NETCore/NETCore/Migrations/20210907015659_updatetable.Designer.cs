﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NETCore.Context;

namespace NETCore.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20210907015659_updatetable")]
    partial class updatetable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NETCore.Models.Account", b =>
                {
                    b.Property<string>("NIK")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NIK");

                    b.ToTable("tb_m_accounts");
                });

            modelBuilder.Entity("NETCore.Models.AccountRole", b =>
                {
                    b.Property<string>("NIK")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("NIK", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("tb_tr_accountroles");
                });

            modelBuilder.Entity("NETCore.Models.Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Degree")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GPA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UniversityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UniversityId");

                    b.ToTable("tb_tr_educations");
                });

            modelBuilder.Entity("NETCore.Models.Person", b =>
                {
                    b.Property<string>("NIK")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GenderName")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.HasKey("NIK");

                    b.ToTable("tb_m_persons");
                });

            modelBuilder.Entity("NETCore.Models.Profiling", b =>
                {
                    b.Property<string>("NIK")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("EducationId")
                        .HasColumnType("int");

                    b.HasKey("NIK");

                    b.HasIndex("EducationId");

                    b.ToTable("tb_tr_profilings");
                });

            modelBuilder.Entity("NETCore.Models.ResetPassword", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NIK")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OTP")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tb_m_reset_passwords");
                });

            modelBuilder.Entity("NETCore.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tb_m_roles");
                });

            modelBuilder.Entity("NETCore.Models.University", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tb_m_universities");
                });

            modelBuilder.Entity("NETCore.Models.Account", b =>
                {
                    b.HasOne("NETCore.Models.Person", "Person")
                        .WithOne("Account")
                        .HasForeignKey("NETCore.Models.Account", "NIK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("NETCore.Models.AccountRole", b =>
                {
                    b.HasOne("NETCore.Models.Account", "Account")
                        .WithMany("AccountRoles")
                        .HasForeignKey("NIK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NETCore.Models.Role", "Role")
                        .WithMany("AccountRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("NETCore.Models.Education", b =>
                {
                    b.HasOne("NETCore.Models.University", "University")
                        .WithMany("Educations")
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("University");
                });

            modelBuilder.Entity("NETCore.Models.Profiling", b =>
                {
                    b.HasOne("NETCore.Models.Education", "Education")
                        .WithMany("Profilings")
                        .HasForeignKey("EducationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NETCore.Models.Account", "Account")
                        .WithOne("Profiling")
                        .HasForeignKey("NETCore.Models.Profiling", "NIK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Education");
                });

            modelBuilder.Entity("NETCore.Models.Account", b =>
                {
                    b.Navigation("AccountRoles");

                    b.Navigation("Profiling");
                });

            modelBuilder.Entity("NETCore.Models.Education", b =>
                {
                    b.Navigation("Profilings");
                });

            modelBuilder.Entity("NETCore.Models.Person", b =>
                {
                    b.Navigation("Account");
                });

            modelBuilder.Entity("NETCore.Models.Role", b =>
                {
                    b.Navigation("AccountRoles");
                });

            modelBuilder.Entity("NETCore.Models.University", b =>
                {
                    b.Navigation("Educations");
                });
#pragma warning restore 612, 618
        }
    }
}
