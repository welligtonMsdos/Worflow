﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Worflow.Dados.EFCore;

namespace Worflow.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Worflow.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Agencia")
                        .IsRequired()
                        .HasColumnType("varchar(4)");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("varchar(14)");

                    b.Property<string>("Conta")
                        .IsRequired()
                        .HasColumnType("varchar(5)");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(50)");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("Fantasia")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Telefone")
                        .HasColumnType("varchar(11)");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.HasIndex("Fantasia")
                        .HasName("IX_CLIENTE_FANTASIA");

                    b.HasIndex("RazaoSocial")
                        .HasName("IX_CLIENTE_RAZAO_SOCIAL");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Worflow.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("varchar(8)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Logadouro")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasColumnType("varchar(2)");

                    b.HasKey("Id");

                    b.HasIndex("Cidade")
                        .HasName("IX_ENDERECO_CIDADE");

                    b.HasIndex("Logadouro")
                        .HasName("IX_ENDERECO_LOGADOURO");

                    b.HasIndex("UF")
                        .HasName("IX_ENDERECO_UF");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("Worflow.Models.Lead", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataAgendada")
                        .HasColumnType("datetime");

                    b.Property<string>("Observacao")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("ProdutoId");

                    b.HasIndex("StatusId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Lead");
                });

            modelBuilder.Entity("Worflow.Models.Perfil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Descricao")
                        .HasName("IX_PERFIL_DESCRICAO");

                    b.ToTable("Perfil");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ativo = true,
                            Descricao = "Consultor"
                        });
                });

            modelBuilder.Entity("Worflow.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("SegmentoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Descricao")
                        .HasName("IX_PRODUTO_DESCRICAO");

                    b.HasIndex("SegmentoId");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("Worflow.Models.Segmento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Descricao")
                        .HasName("IX_SEGMENTO_DESCRICAO");

                    b.ToTable("Segmento");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ativo = true,
                            Descricao = "Agro"
                        },
                        new
                        {
                            Id = 2,
                            Ativo = true,
                            Descricao = "Cib"
                        },
                        new
                        {
                            Id = 3,
                            Ativo = true,
                            Descricao = "Middle"
                        },
                        new
                        {
                            Id = 4,
                            Ativo = true,
                            Descricao = "Large"
                        });
                });

            modelBuilder.Entity("Worflow.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Descricao")
                        .HasName("IX_STATUS_DESCRICAO");

                    b.ToTable("Status");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ativo = true,
                            Descricao = "Ativo"
                        },
                        new
                        {
                            Id = 2,
                            Ativo = true,
                            Descricao = "Em andamento"
                        },
                        new
                        {
                            Id = 3,
                            Ativo = true,
                            Descricao = "Finalizado"
                        });
                });

            modelBuilder.Entity("Worflow.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<int>("PerfilId")
                        .HasColumnType("int");

                    b.Property<string>("RACF")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Nome")
                        .HasName("IX_USUARIO_NOME");

                    b.HasIndex("PerfilId");

                    b.ToTable("Usuario");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ativo = true,
                            Nome = "Lionel Messi",
                            PerfilId = 1
                        },
                        new
                        {
                            Id = 2,
                            Ativo = true,
                            Nome = "Cristiano Ronaldo",
                            PerfilId = 1
                        },
                        new
                        {
                            Id = 3,
                            Ativo = true,
                            Nome = "Neymar Junior",
                            PerfilId = 1
                        });
                });

            modelBuilder.Entity("Worflow.Models.Cliente", b =>
                {
                    b.HasOne("Worflow.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Worflow.Models.Lead", b =>
                {
                    b.HasOne("Worflow.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Worflow.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Worflow.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Worflow.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Worflow.Models.Produto", b =>
                {
                    b.HasOne("Worflow.Models.Segmento", "Segmento")
                        .WithMany("Produtos")
                        .HasForeignKey("SegmentoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Worflow.Models.Usuario", b =>
                {
                    b.HasOne("Worflow.Models.Perfil", "Perfil")
                        .WithMany("Usuario")
                        .HasForeignKey("PerfilId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
