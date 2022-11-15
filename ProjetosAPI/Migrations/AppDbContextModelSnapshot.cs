﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetosAPI.Data;

namespace ProjetosAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjetosAPI.Models.Anotacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProjetoId")
                        .HasColumnType("int");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProjetoId");

                    b.ToTable("Anotacao");
                });

            modelBuilder.Entity("ProjetosAPI.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("ProjetosAPI.Models.Imagem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Caminho")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjetoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjetoId");

                    b.ToTable("Imagem");
                });

            modelBuilder.Entity("ProjetosAPI.Models.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnidadeMedida")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Material");
                });

            modelBuilder.Entity("ProjetosAPI.Models.MaterialProjeto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MaterialId")
                        .HasColumnType("int");

                    b.Property<int>("ProjetoId")
                        .HasColumnType("int");

                    b.Property<float>("Quantidade")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("MaterialId");

                    b.HasIndex("ProjetoId");

                    b.ToTable("MaterialProjeto");
                });

            modelBuilder.Entity("ProjetosAPI.Models.Movimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MaterialId")
                        .HasColumnType("int");

                    b.Property<int>("OrdemProducaoId")
                        .HasColumnType("int");

                    b.Property<float>("Quantidade")
                        .HasColumnType("real");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("Id");

                    b.HasIndex("MaterialId");

                    b.ToTable("Movimento");
                });

            modelBuilder.Entity("ProjetosAPI.Models.MovimentoProjeto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProdutoProntoId")
                        .HasColumnType("int");

                    b.Property<float>("Quantidade")
                        .HasColumnType("real");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoProntoId");

                    b.ToTable("MovimentoProjeto");
                });

            modelBuilder.Entity("ProjetosAPI.Models.OrdemProducao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProjetoId")
                        .HasColumnType("int");

                    b.Property<float>("Quantidade")
                        .HasColumnType("real");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("Id");

                    b.HasIndex("ProjetoId");

                    b.ToTable("OrdemProducao");
                });

            modelBuilder.Entity("ProjetosAPI.Models.ProdutoPronto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProjetoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjetoId");

                    b.ToTable("ProdutoPronto");
                });

            modelBuilder.Entity("ProjetosAPI.Models.Projeto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Capa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Preco")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Projeto");
                });

            modelBuilder.Entity("ProjetosAPI.Models.Video", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjetoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjetoId");

                    b.ToTable("Video");
                });

            modelBuilder.Entity("ProjetosAPI.Models.Anotacao", b =>
                {
                    b.HasOne("ProjetosAPI.Models.Projeto", "Projeto")
                        .WithMany("Anotacoes")
                        .HasForeignKey("ProjetoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projeto");
                });

            modelBuilder.Entity("ProjetosAPI.Models.Imagem", b =>
                {
                    b.HasOne("ProjetosAPI.Models.Projeto", "Projeto")
                        .WithMany("Imagens")
                        .HasForeignKey("ProjetoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projeto");
                });

            modelBuilder.Entity("ProjetosAPI.Models.MaterialProjeto", b =>
                {
                    b.HasOne("ProjetosAPI.Models.Material", "Material")
                        .WithMany("MateriaisProjeto")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetosAPI.Models.Projeto", "Projeto")
                        .WithMany("MateriaisProjeto")
                        .HasForeignKey("ProjetoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Material");

                    b.Navigation("Projeto");
                });

            modelBuilder.Entity("ProjetosAPI.Models.Movimento", b =>
                {
                    b.HasOne("ProjetosAPI.Models.Material", "Material")
                        .WithMany("Movimentos")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Material");
                });

            modelBuilder.Entity("ProjetosAPI.Models.MovimentoProjeto", b =>
                {
                    b.HasOne("ProjetosAPI.Models.ProdutoPronto", "ProdutoPronto")
                        .WithMany("Movimentos")
                        .HasForeignKey("ProdutoProntoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProdutoPronto");
                });

            modelBuilder.Entity("ProjetosAPI.Models.OrdemProducao", b =>
                {
                    b.HasOne("ProjetosAPI.Models.Projeto", "Projeto")
                        .WithMany("OrdensProducao")
                        .HasForeignKey("ProjetoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projeto");
                });

            modelBuilder.Entity("ProjetosAPI.Models.ProdutoPronto", b =>
                {
                    b.HasOne("ProjetosAPI.Models.Projeto", "Projeto")
                        .WithMany("ProdutosProntos")
                        .HasForeignKey("ProjetoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projeto");
                });

            modelBuilder.Entity("ProjetosAPI.Models.Projeto", b =>
                {
                    b.HasOne("ProjetosAPI.Models.Categoria", "Categoria")
                        .WithMany("Projetos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("ProjetosAPI.Models.Video", b =>
                {
                    b.HasOne("ProjetosAPI.Models.Projeto", "Projeto")
                        .WithMany("Videos")
                        .HasForeignKey("ProjetoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projeto");
                });

            modelBuilder.Entity("ProjetosAPI.Models.Categoria", b =>
                {
                    b.Navigation("Projetos");
                });

            modelBuilder.Entity("ProjetosAPI.Models.Material", b =>
                {
                    b.Navigation("MateriaisProjeto");

                    b.Navigation("Movimentos");
                });

            modelBuilder.Entity("ProjetosAPI.Models.ProdutoPronto", b =>
                {
                    b.Navigation("Movimentos");
                });

            modelBuilder.Entity("ProjetosAPI.Models.Projeto", b =>
                {
                    b.Navigation("Anotacoes");

                    b.Navigation("Imagens");

                    b.Navigation("MateriaisProjeto");

                    b.Navigation("OrdensProducao");

                    b.Navigation("ProdutosProntos");

                    b.Navigation("Videos");
                });
#pragma warning restore 612, 618
        }
    }
}
