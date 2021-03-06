﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dev.budget;

namespace dev.budget.Migrations
{
    [DbContext(typeof(DevBudgetContext))]
    [Migration("20200927132629_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8");

            modelBuilder.Entity("dev.budget.business.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .HasColumnName("city")
                        .HasColumnType("TEXT");

                    b.Property<string>("Complement")
                        .HasColumnName("complement")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Number")
                        .HasColumnName("number")
                        .HasColumnType("TEXT");

                    b.Property<string>("PostalCode")
                        .HasColumnName("postal_code")
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .HasColumnName("state")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("addresses");
                });

            modelBuilder.Entity("dev.budget.business.Entities.Budget", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DesignerCount")
                        .HasColumnName("designer_count")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DevCount")
                        .HasColumnName("dev_count")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Duration")
                        .HasColumnName("duration")
                        .HasColumnType("INTEGER");

                    b.Property<int>("POCount")
                        .HasColumnName("po_count")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PersonId")
                        .HasColumnName("person_id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SMCount")
                        .HasColumnName("sm_count")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("budgets");
                });

            modelBuilder.Entity("dev.budget.business.Entities.Enterprise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CNPJ")
                        .HasColumnName("cnpj")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("enterprises");
                });

            modelBuilder.Entity("dev.budget.business.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CPF")
                        .HasColumnName("cpf")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnName("last_name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("people");
                });

            modelBuilder.Entity("dev.budget.business.Entities.PersonAddress", b =>
                {
                    b.Property<int>("AddressId")
                        .HasColumnName("address_id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PersonId")
                        .HasColumnName("person_id")
                        .HasColumnType("INTEGER");

                    b.HasKey("AddressId", "PersonId");

                    b.HasIndex("PersonId");

                    b.ToTable("people_addresses");
                });

            modelBuilder.Entity("dev.budget.business.Entities.PersonEnterprise", b =>
                {
                    b.Property<int>("EnterpriseId")
                        .HasColumnName("enterprise_id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PersonId")
                        .HasColumnName("person_id")
                        .HasColumnType("INTEGER");

                    b.HasKey("EnterpriseId", "PersonId");

                    b.HasIndex("PersonId");

                    b.ToTable("PeopleEnterpeises");
                });

            modelBuilder.Entity("dev.budget.business.Entities.User", b =>
                {
                    b.Property<int>("PersonId")
                        .HasColumnName("person_id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .HasColumnName("password")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasColumnName("username")
                        .HasColumnType("TEXT");

                    b.HasKey("PersonId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("dev.budget.business.Entities.Budget", b =>
                {
                    b.HasOne("dev.budget.business.Entities.Person", "Person")
                        .WithMany("Budgets")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("dev.budget.business.Entities.PersonAddress", b =>
                {
                    b.HasOne("dev.budget.business.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dev.budget.business.Entities.Person", "Person")
                        .WithMany("PeopleAddresses")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("dev.budget.business.Entities.PersonEnterprise", b =>
                {
                    b.HasOne("dev.budget.business.Entities.Enterprise", "Enterprise")
                        .WithMany("PersonEnterprise")
                        .HasForeignKey("EnterpriseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dev.budget.business.Entities.Person", "Person")
                        .WithMany("PersonEnterprise")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("dev.budget.business.Entities.User", b =>
                {
                    b.HasOne("dev.budget.business.Entities.Person", "Person")
                        .WithOne("User")
                        .HasForeignKey("dev.budget.business.Entities.User", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
