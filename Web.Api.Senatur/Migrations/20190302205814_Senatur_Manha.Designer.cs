﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Senai.Web.Api.Senatur.Context;

namespace Senai.Web.Api.Senatur.Migrations
{
    [DbContext(typeof(SenaturContext))]
    [Migration("20190302205814_Senatur_Manha")]
    partial class Senatur_Manha
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Senai.Web.Api.Senatur.Domains.PacotesDomain", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("PacoteId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnName("Ativo")
                        .HasColumnType("BIT");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnName("NomeCidade")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(250);

                    b.Property<DateTime>("DataIda")
                        .HasColumnName("DataIda")
                        .HasColumnType("DATE");

                    b.Property<DateTime>("DataVolta")
                        .HasColumnName("DataVolta")
                        .HasColumnType("DATE");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnName("Descricao")
                        .HasColumnType("TEXT")
                        .HasMaxLength(1000);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("PacoteNome")
                        .HasColumnType("VARCHAR(250)")
                        .HasMaxLength(250);

                    b.Property<decimal>("Valor")
                        .HasColumnName("Valor")
                        .HasColumnType("MONEY");

                    b.HasKey("ID");

                    b.ToTable("Pacotes");
                });

            modelBuilder.Entity("Senai.Web.Api.Senatur.Domains.UsuariosDomain", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("UsuarioId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("Email")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnName("Senha")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<short>("TipoUsuario")
                        .HasColumnName("TipoUsuario")
                        .HasColumnType("SMALLINT");

                    b.HasKey("ID");

                    b.ToTable("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}