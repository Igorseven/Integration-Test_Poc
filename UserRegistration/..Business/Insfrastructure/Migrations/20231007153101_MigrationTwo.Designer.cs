﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserRegistration.API.Business.Insfrastructure.ORM.Context;

#nullable disable

namespace UserRegistration.API.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20231007153101_MigrationTwo")]
    partial class MigrationTwo
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("UserRegistration.API.Business.Domain.Entities.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AddressId"));

                    b.Property<byte>("AddressType")
                        .HasColumnType("tinyint")
                        .HasColumnName("address_type");

                    b.Property<string>("City")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("varchar(70)")
                        .HasColumnName("city");

                    b.Property<int>("ClientId")
                        .HasColumnType("int")
                        .HasColumnName("client_id");

                    b.Property<string>("Complement")
                        .IsUnicode(true)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("complement");

                    b.Property<string>("Country")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("varchar(70)")
                        .HasColumnName("country");

                    b.Property<string>("District")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("varchar(70)")
                        .HasColumnName("district");

                    b.Property<string>("Localization")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("localization");

                    b.Property<string>("Number")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("number");

                    b.Property<string>("State")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("state");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("zip_code");

                    b.HasKey("AddressId");

                    b.HasIndex("ClientId");

                    b.ToTable("Address", "CustomerBase");
                });

            modelBuilder.Entity("UserRegistration.API.Business.Domain.Entities.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientId"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("full_name");

                    b.HasKey("ClientId");

                    b.ToTable("Client", "CustomerBase");
                });

            modelBuilder.Entity("UserRegistration.API.Business.Domain.Entities.EmailAddress", b =>
                {
                    b.Property<int>("EmailAddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmailAddressId"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int")
                        .HasColumnName("client_id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("email");

                    b.Property<byte>("EmailType")
                        .HasColumnType("tinyint")
                        .HasColumnName("email_type");

                    b.HasKey("EmailAddressId");

                    b.HasIndex("ClientId");

                    b.ToTable("EmailAddress", "CustomerBase");
                });

            modelBuilder.Entity("UserRegistration.API.Business.Domain.Entities.Telephone", b =>
                {
                    b.Property<int>("TelephoneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TelephoneId"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int")
                        .HasColumnName("client_id");

                    b.Property<string>("Ddd")
                        .IsUnicode(true)
                        .HasColumnType("varchar(3)")
                        .HasColumnName("ddd");

                    b.Property<string>("Ddi")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("varchar(6)")
                        .HasColumnName("ddi");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("varchar(11)")
                        .HasColumnName("phone_number");

                    b.Property<byte>("TelephoneType")
                        .HasColumnType("tinyint")
                        .HasColumnName("telephone_type");

                    b.HasKey("TelephoneId");

                    b.HasIndex("ClientId");

                    b.ToTable("Telephone", "CustomerBase");
                });

            modelBuilder.Entity("UserRegistration.API.Business.Domain.Entities.Address", b =>
                {
                    b.HasOne("UserRegistration.API.Business.Domain.Entities.Client", null)
                        .WithMany("Addresses")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UserRegistration.API.Business.Domain.Entities.EmailAddress", b =>
                {
                    b.HasOne("UserRegistration.API.Business.Domain.Entities.Client", null)
                        .WithMany("Emails")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UserRegistration.API.Business.Domain.Entities.Telephone", b =>
                {
                    b.HasOne("UserRegistration.API.Business.Domain.Entities.Client", null)
                        .WithMany("Telephones")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UserRegistration.API.Business.Domain.Entities.Client", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Emails");

                    b.Navigation("Telephones");
                });
#pragma warning restore 612, 618
        }
    }
}
