﻿// <auto-generated />
using AgendaTelefonicaWeb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AgendaTelefonicaWeb.Migrations
{
    [DbContext(typeof(AgendaTelefonicaWebContext))]
    [Migration("20250403092652_Correcao")]
    partial class Correcao
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("AgendaTelefonicaWeb.Models.Contato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Idade")
                        .HasColumnType("int")
                        .HasColumnName("Idade");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.ToTable("Contato");
                });

            modelBuilder.Entity("AgendaTelefonicaWeb.Models.Telefone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ContatoId")
                        .HasColumnType("int")
                        .HasColumnName("IdContato");

                    b.Property<int>("Numero")
                        .HasMaxLength(16)
                        .HasColumnType("int")
                        .HasColumnName("Numero");

                    b.HasKey("Id");

                    b.HasIndex("ContatoId");

                    b.ToTable("Telefone");
                });

            modelBuilder.Entity("AgendaTelefonicaWeb.Models.Telefone", b =>
                {
                    b.HasOne("AgendaTelefonicaWeb.Models.Contato", "Contato")
                        .WithMany("Telefones")
                        .HasForeignKey("ContatoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contato");
                });

            modelBuilder.Entity("AgendaTelefonicaWeb.Models.Contato", b =>
                {
                    b.Navigation("Telefones");
                });
#pragma warning restore 612, 618
        }
    }
}
