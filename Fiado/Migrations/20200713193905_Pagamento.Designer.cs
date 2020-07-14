﻿// <auto-generated />
using System;
using Fiado;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Fiado.Migrations
{
    [DbContext(typeof(FiadoContexto))]
    [Migration("20200713193905_Pagamento")]
    partial class Pagamento
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Fiado.Models.ClienteModelos.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContaId");

                    b.Property<string>("Endereco")
                        .IsRequired();

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<string>("Telefone")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ContaId")
                        .IsUnique();

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Fiado.Models.ContaModelos.Conta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Status");

                    b.Property<float>("Total");

                    b.HasKey("Id");

                    b.ToTable("Contas");
                });

            modelBuilder.Entity("Fiado.Models.NotaModelos.Nota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Atendente");

                    b.Property<int>("ContaId");

                    b.Property<DateTime>("Data");

                    b.Property<string>("Detalhes");

                    b.Property<float>("Valor");

                    b.HasKey("Id");

                    b.ToTable("Notas");
                });

            modelBuilder.Entity("Fiado.Models.PagamentoModelos.Pagamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Atendente");

                    b.Property<int>("ContaId");

                    b.Property<DateTime>("Data");

                    b.Property<string>("Detalhes");

                    b.Property<float>("Valor");

                    b.HasKey("Id");

                    b.ToTable("Pagamentos");
                });

            modelBuilder.Entity("Fiado.Models.ClienteModelos.Cliente", b =>
                {
                    b.HasOne("Fiado.Models.ContaModelos.Conta", "Conta")
                        .WithOne("Cliente")
                        .HasForeignKey("Fiado.Models.ClienteModelos.Cliente", "ContaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
