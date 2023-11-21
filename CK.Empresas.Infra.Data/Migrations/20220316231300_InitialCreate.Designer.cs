﻿// <auto-generated />
using System;
using Octoplex.Empresas.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Octoplex.Empresas.Infra.Data.Migrations
{
    [DbContext(typeof(EmpresaDbContext))]
    [Migration("20220316231300_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Octoplex.Empresas.Domain.Empresas.Empresa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("ChavePrivada")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("ChavePrivada");

                    b.Property<string>("CpfCnpj")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("CpfCnpj");

                    b.Property<int>("Crt")
                        .HasMaxLength(1)
                        .HasColumnType("int")
                        .HasColumnName("RegimeTributario");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("IeRg")
                        .HasMaxLength(18)
                        .HasColumnType("nvarchar(18)")
                        .HasColumnName("IeRg");

                    b.Property<string>("InscMunicipal")
                        .HasMaxLength(18)
                        .HasColumnType("nvarchar(18)")
                        .HasColumnName("InscMunicipal");

                    b.Property<string>("NomeFantasia")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("NomeFantasia");

                    b.Property<string>("RazaoSocial")
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)")
                        .HasColumnName("RazaoSocial");

                    b.HasKey("Id")
                        .HasName("id");

                    b.ToTable("Empresas");
                });
#pragma warning restore 612, 618
        }
    }
}
