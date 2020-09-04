﻿// <auto-generated />
using DictionaryV2.DataAccess.Concreate.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace DictionaryV2.MvcUI.Migrations
{
    [DbContext(typeof(DictionaryContext))]
    [Migration("20191109085319_RepatAdded")]
    partial class RepatAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DictionaryV2.Entity.Concreate.EngDictionary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EngStr");

                    b.Property<DateTime>("InsertDate");

                    b.Property<string>("TrStr");

                    b.HasKey("Id");

                    b.ToTable("EngDictionary");
                });

            modelBuilder.Entity("DictionaryV2.Entity.Concreate.Repeat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DictionaryId");

                    b.Property<bool>("DoneFlag");

                    b.Property<DateTime>("InsertDate");

                    b.HasKey("Id");

                    b.ToTable("Repeat");
                });
#pragma warning restore 612, 618
        }
    }
}