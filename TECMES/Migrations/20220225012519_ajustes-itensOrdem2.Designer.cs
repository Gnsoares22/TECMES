﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TECMES.Models;

namespace TECMES.Migrations
{
    [DbContext(typeof(ContextDB))]
    [Migration("20220225012519_ajustes-itensOrdem2")]
    partial class ajustesitensOrdem2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TECMES.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("TECMES.Models.Maquina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Maquina");
                });

            modelBuilder.Entity("TECMES.Models.OrdemProducao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MaquinaID")
                        .HasColumnType("int");

                    b.Property<int>("PedidoID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Prazo")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProdutoID")
                        .HasColumnType("int");

                    b.Property<int>("StatusID")
                        .HasColumnType("int");

                    b.Property<int?>("quantidade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MaquinaID");

                    b.HasIndex("PedidoID");

                    b.HasIndex("ProdutoID");

                    b.HasIndex("StatusID");

                    b.ToTable("OrdemProducao");
                });

            modelBuilder.Entity("TECMES.Models.OrdemProducaoSequencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("NumeroSequencia")
                        .HasColumnType("int");

                    b.Property<int>("OrdemProducaoID")
                        .HasColumnType("int");

                    b.Property<int?>("OrdemProducaoStatusId")
                        .HasColumnType("int");

                    b.Property<int>("ProdutoID")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrdemProducaoID");

                    b.HasIndex("OrdemProducaoStatusId");

                    b.HasIndex("ProdutoID");

                    b.ToTable("OrdemProducaoSequencia");
                });

            modelBuilder.Entity("TECMES.Models.OrdemProducaoStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OrdemProducaoStatus");
                });

            modelBuilder.Entity("TECMES.Models.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteID")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProdutoID")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteID");

                    b.HasIndex("ProdutoID");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("TECMES.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("preco")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("quantidade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("TECMES.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("TECMES.Models.OrdemProducao", b =>
                {
                    b.HasOne("TECMES.Models.Maquina", "maquinas")
                        .WithMany("ordemProducao")
                        .HasForeignKey("MaquinaID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("TECMES.Models.Pedido", "pedido")
                        .WithMany("ordemProducao")
                        .HasForeignKey("PedidoID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TECMES.Models.Produto", "produtos")
                        .WithMany("ordemProducao")
                        .HasForeignKey("ProdutoID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TECMES.Models.OrdemProducaoStatus", "status")
                        .WithMany("OrdemProducao")
                        .HasForeignKey("StatusID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("TECMES.Models.OrdemProducaoSequencia", b =>
                {
                    b.HasOne("TECMES.Models.OrdemProducao", null)
                        .WithMany("sequencia")
                        .HasForeignKey("OrdemProducaoID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TECMES.Models.OrdemProducaoStatus", null)
                        .WithMany("sequencia")
                        .HasForeignKey("OrdemProducaoStatusId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("TECMES.Models.Produto", "produto")
                        .WithMany("OrdemProducaoSequencia")
                        .HasForeignKey("ProdutoID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("TECMES.Models.Pedido", b =>
                {
                    b.HasOne("TECMES.Models.Cliente", "cliente")
                        .WithMany("Pedido")
                        .HasForeignKey("ClienteID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TECMES.Models.Produto", "produto")
                        .WithMany("Pedido")
                        .HasForeignKey("ProdutoID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
