﻿// <auto-generated />
using System;
using DatabaseFirst.Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DatabaseFirst.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240409032242_relacionMuchosAMuchos")]
    partial class relacionMuchosAMuchos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DatabaseFirst.Models.Articulo", b =>
                {
                    b.Property<int>("Articulo_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Articulo_Id"), 1L, 1);

                    b.Property<string>("Calificacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Categoria_Id")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("TituloArticulo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Articulo");

                    b.HasKey("Articulo_Id");

                    b.HasIndex("Categoria_Id");

                    b.ToTable("Tbl_Articulo");
                });

            modelBuilder.Entity("DatabaseFirst.Models.ArticuloEtiqueta", b =>
                {
                    b.Property<int>("Etiqueta_Id")
                        .HasColumnType("int");

                    b.Property<int>("Articulo_Id")
                        .HasColumnType("int");

                    b.HasKey("Etiqueta_Id", "Articulo_Id");

                    b.HasIndex("Articulo_Id");

                    b.ToTable("ArticuloEtiqueta");
                });

            modelBuilder.Entity("DatabaseFirst.Models.Categoria", b =>
                {
                    b.Property<int>("Categoria_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Categoria_Id"), 1L, 1);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Categoria_Id");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("DatabaseFirst.Models.DetalleUsuario", b =>
                {
                    b.Property<int>("DetalleUsuario_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DetalleUsuario_Id"), 1L, 1);

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Depórte")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mascota")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DetalleUsuario_Id");

                    b.ToTable("DetalleUsuario");
                });

            modelBuilder.Entity("DatabaseFirst.Models.Etiqueta", b =>
                {
                    b.Property<int>("Etiqueta_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Etiqueta_Id"), 1L, 1);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Etiqueta_Id");

                    b.ToTable("Etiqueta");
                });

            modelBuilder.Entity("DatabaseFirst.Models.nota", b =>
                {
                    b.Property<int>("idnota")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idnota"), 1L, 1);

                    b.Property<string>("descripcion")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("date");

                    b.Property<string>("titulo")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("usuario_id")
                        .HasColumnType("int");

                    b.HasKey("idnota");

                    b.ToTable("notas");
                });

            modelBuilder.Entity("DatabaseFirst.Models.usuario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("DetalleUsuario_Id")
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("DetalleUsuario_Id")
                        .IsUnique();

                    b.ToTable("usuario");
                });

            modelBuilder.Entity("DatabaseFirst.Models.Articulo", b =>
                {
                    b.HasOne("DatabaseFirst.Models.Categoria", "Categoria")
                        .WithMany("Articulo")
                        .HasForeignKey("Categoria_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("DatabaseFirst.Models.ArticuloEtiqueta", b =>
                {
                    b.HasOne("DatabaseFirst.Models.Articulo", "Articulo")
                        .WithMany("ArticuloEtiquetas")
                        .HasForeignKey("Articulo_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DatabaseFirst.Models.Etiqueta", "Etiqueta")
                        .WithMany("ArticuloEtiquetas")
                        .HasForeignKey("Etiqueta_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Articulo");

                    b.Navigation("Etiqueta");
                });

            modelBuilder.Entity("DatabaseFirst.Models.usuario", b =>
                {
                    b.HasOne("DatabaseFirst.Models.DetalleUsuario", "DetalleUsuario")
                        .WithOne("usuario")
                        .HasForeignKey("DatabaseFirst.Models.usuario", "DetalleUsuario_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DetalleUsuario");
                });

            modelBuilder.Entity("DatabaseFirst.Models.Articulo", b =>
                {
                    b.Navigation("ArticuloEtiquetas");
                });

            modelBuilder.Entity("DatabaseFirst.Models.Categoria", b =>
                {
                    b.Navigation("Articulo");
                });

            modelBuilder.Entity("DatabaseFirst.Models.DetalleUsuario", b =>
                {
                    b.Navigation("usuario");
                });

            modelBuilder.Entity("DatabaseFirst.Models.Etiqueta", b =>
                {
                    b.Navigation("ArticuloEtiquetas");
                });
#pragma warning restore 612, 618
        }
    }
}