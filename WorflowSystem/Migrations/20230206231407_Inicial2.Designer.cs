﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Worflow.Dados.EFCore;

namespace Worflow.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230206231407_Inicial2")]
    partial class Inicial2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Worflow.Models.Agenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Comentario")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<DateTime>("DataAgendada")
                        .HasColumnType("datetime");

                    b.Property<int>("LeadId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LeadId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Agenda");
                });

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
                        .HasColumnType("varchar(8)")
                        .HasMaxLength(8);

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
                        .HasColumnType("varchar(2)")
                        .HasMaxLength(2);

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

                    b.Property<int>("SegmentoId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("ProdutoId");

                    b.HasIndex("SegmentoId");

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
                        },
                        new
                        {
                            Id = 2,
                            Ativo = true,
                            Descricao = "Cotação"
                        },
                        new
                        {
                            Id = 3,
                            Ativo = true,
                            Descricao = "Implantação"
                        },
                        new
                        {
                            Id = 4,
                            Ativo = true,
                            Descricao = "Subscrição"
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

                    b.HasKey("Id");

                    b.HasIndex("Descricao")
                        .HasName("IX_PRODUTO_DESCRICAO");

                    b.ToTable("Produto");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ativo = true,
                            Descricao = "Garantia"
                        },
                        new
                        {
                            Id = 2,
                            Ativo = true,
                            Descricao = "Vida em Grupo"
                        },
                        new
                        {
                            Id = 3,
                            Ativo = true,
                            Descricao = "Patrimonial"
                        },
                        new
                        {
                            Id = 4,
                            Ativo = true,
                            Descricao = "Odonto"
                        });
                });

            modelBuilder.Entity("Worflow.Models.ProdutoSegmento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<int>("SegmentoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.HasIndex("SegmentoId");

                    b.ToTable("ProdutoSegmento");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProdutoId = 1,
                            SegmentoId = 1
                        },
                        new
                        {
                            Id = 2,
                            ProdutoId = 2,
                            SegmentoId = 1
                        },
                        new
                        {
                            Id = 3,
                            ProdutoId = 3,
                            SegmentoId = 1
                        },
                        new
                        {
                            Id = 4,
                            ProdutoId = 1,
                            SegmentoId = 2
                        },
                        new
                        {
                            Id = 5,
                            ProdutoId = 4,
                            SegmentoId = 2
                        },
                        new
                        {
                            Id = 6,
                            ProdutoId = 1,
                            SegmentoId = 3
                        },
                        new
                        {
                            Id = 7,
                            ProdutoId = 1,
                            SegmentoId = 4
                        },
                        new
                        {
                            Id = 8,
                            ProdutoId = 2,
                            SegmentoId = 4
                        });
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
                        .IsRequired()
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
                            PerfilId = 1,
                            RACF = "LIOMES"
                        },
                        new
                        {
                            Id = 2,
                            Ativo = true,
                            Nome = "Cristiano Ronaldo",
                            PerfilId = 1,
                            RACF = "CRISRO"
                        },
                        new
                        {
                            Id = 3,
                            Ativo = true,
                            Nome = "Neymar Junior",
                            PerfilId = 1,
                            RACF = "NEYJU"
                        });
                });

            modelBuilder.Entity("Worflow.Models.Agenda", b =>
                {
                    b.HasOne("Worflow.Models.Lead", "Lead")
                        .WithMany("Agenda")
                        .HasForeignKey("LeadId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Worflow.Models.Usuario", "Usuario")
                        .WithMany("Agenda")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Worflow.Models.Cliente", b =>
                {
                    b.HasOne("Worflow.Models.Endereco", "Endereco")
                        .WithMany("Cliente")
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Worflow.Models.Lead", b =>
                {
                    b.HasOne("Worflow.Models.Cliente", "Cliente")
                        .WithMany("Lead")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Worflow.Models.Produto", "Produto")
                        .WithMany("Lead")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Worflow.Models.Segmento", "Segmento")
                        .WithMany("Lead")
                        .HasForeignKey("SegmentoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Worflow.Models.Status", "Status")
                        .WithMany("Lead")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Worflow.Models.Usuario", "Usuario")
                        .WithMany("Lead")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Worflow.Models.ProdutoSegmento", b =>
                {
                    b.HasOne("Worflow.Models.Produto", "produto")
                        .WithMany("ProdutoSegmento")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Worflow.Models.Segmento", "Segmento")
                        .WithMany("ProdutoSegmento")
                        .HasForeignKey("SegmentoId")
                        .OnDelete(DeleteBehavior.Cascade)
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