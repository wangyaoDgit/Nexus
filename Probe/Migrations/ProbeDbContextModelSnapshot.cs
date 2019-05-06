﻿// <auto-generated />
using System;
using Aiursoft.Probe.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Aiursoft.Probe.Migrations
{
    [DbContext(typeof(ProbeDbContext))]
    partial class ProbeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Aiursoft.Pylon.Models.Probe.File", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContextId");

                    b.Property<string>("FileName");

                    b.Property<DateTime>("UploadTime");

                    b.HasKey("Id");

                    b.HasIndex("ContextId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("Aiursoft.Pylon.Models.Probe.Folder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ContextId");

                    b.Property<string>("FolderName");

                    b.HasKey("Id");

                    b.HasIndex("ContextId");

                    b.ToTable("Folders");
                });

            modelBuilder.Entity("Aiursoft.Pylon.Models.Probe.ProbeApp", b =>
                {
                    b.Property<string>("AppId")
                        .ValueGeneratedOnAdd();

                    b.HasKey("AppId");

                    b.ToTable("Apps");
                });

            modelBuilder.Entity("Aiursoft.Pylon.Models.Probe.Site", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AppId");

                    b.Property<int>("FolderId");

                    b.Property<string>("SiteName");

                    b.HasKey("Id");

                    b.HasIndex("AppId");

                    b.HasIndex("FolderId");

                    b.ToTable("Sites");
                });

            modelBuilder.Entity("Aiursoft.Pylon.Models.Probe.File", b =>
                {
                    b.HasOne("Aiursoft.Pylon.Models.Probe.Folder", "Context")
                        .WithMany("Files")
                        .HasForeignKey("ContextId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Aiursoft.Pylon.Models.Probe.Folder", b =>
                {
                    b.HasOne("Aiursoft.Pylon.Models.Probe.Folder", "Context")
                        .WithMany("SubFolders")
                        .HasForeignKey("ContextId");
                });

            modelBuilder.Entity("Aiursoft.Pylon.Models.Probe.Site", b =>
                {
                    b.HasOne("Aiursoft.Pylon.Models.Probe.ProbeApp", "Context")
                        .WithMany("Sites")
                        .HasForeignKey("AppId");

                    b.HasOne("Aiursoft.Pylon.Models.Probe.Folder", "Root")
                        .WithMany()
                        .HasForeignKey("FolderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
