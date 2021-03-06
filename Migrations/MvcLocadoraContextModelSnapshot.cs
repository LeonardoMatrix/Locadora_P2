﻿// <auto-generated />
using System;
using Locadora.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Locadora.Migrations
{
    [DbContext(typeof(MvcLocadoraContext))]
    partial class MvcLocadoraContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("Locadora.Models.Ator", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AtorPrincipal");

                    b.Property<int?>("VideoCodigoVideo");

                    b.HasKey("ID");

                    b.HasIndex("VideoCodigoVideo");

                    b.ToTable("Ator");
                });

            modelBuilder.Entity("Locadora.Models.Cliente", b =>
                {
                    b.Property<int>("CPF")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.Property<string>("Tel");

                    b.HasKey("CPF");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Locadora.Models.DVD", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("LocacaoCodigoLocacao");

                    b.Property<int?>("VideoCodigoVideo");

                    b.HasKey("ID");

                    b.HasIndex("LocacaoCodigoLocacao");

                    b.HasIndex("VideoCodigoVideo");

                    b.ToTable("DVD");
                });

            modelBuilder.Entity("Locadora.Models.Locacao", b =>
                {
                    b.Property<int>("CodigoLocacao")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ClienteCPF");

                    b.Property<DateTime>("DataDevolucao");

                    b.Property<DateTime>("DataLocacao");

                    b.Property<decimal>("Valor");

                    b.HasKey("CodigoLocacao");

                    b.HasIndex("ClienteCPF");

                    b.ToTable("Locacao");
                });

            modelBuilder.Entity("Locadora.Models.Sessao", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao");

                    b.Property<string>("Localizacao");

                    b.HasKey("ID");

                    b.ToTable("Sessao");
                });

            modelBuilder.Entity("Locadora.Models.Video", b =>
                {
                    b.Property<int>("CodigoVideo")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Disponibilidade");

                    b.Property<string>("Genero");

                    b.Property<int>("QuantidadeEstoque");

                    b.Property<int?>("SessaoID");

                    b.Property<string>("Titulo");

                    b.HasKey("CodigoVideo");

                    b.HasIndex("SessaoID");

                    b.ToTable("Videos");
                });

            modelBuilder.Entity("Locadora.Models.Ator", b =>
                {
                    b.HasOne("Locadora.Models.Video", "Video")
                        .WithMany()
                        .HasForeignKey("VideoCodigoVideo");
                });

            modelBuilder.Entity("Locadora.Models.DVD", b =>
                {
                    b.HasOne("Locadora.Models.Locacao", "Locacao")
                        .WithMany()
                        .HasForeignKey("LocacaoCodigoLocacao");

                    b.HasOne("Locadora.Models.Video", "Video")
                        .WithMany()
                        .HasForeignKey("VideoCodigoVideo");
                });

            modelBuilder.Entity("Locadora.Models.Locacao", b =>
                {
                    b.HasOne("Locadora.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteCPF");
                });

            modelBuilder.Entity("Locadora.Models.Video", b =>
                {
                    b.HasOne("Locadora.Models.Sessao", "Sessao")
                        .WithMany()
                        .HasForeignKey("SessaoID");
                });
#pragma warning restore 612, 618
        }
    }
}
