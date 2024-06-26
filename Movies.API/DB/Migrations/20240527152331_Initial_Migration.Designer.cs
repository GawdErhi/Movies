﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Movies.API.DB;

#nullable disable

namespace Movies.API.DB.Migrations
{
    [DbContext(typeof(MoviesAPIDbContext))]
    [Migration("20240527152331_Initial_Migration")]
    partial class Initial_Migration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Movies.API.Models.Actor", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("Movies.API.Models.Country", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Movies.API.Models.Director", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Directors");
                });

            modelBuilder.Entity("Movies.API.Models.Genre", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Movies.API.Models.Language", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("Movies.API.Models.MovieDetail", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Awards")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BoxOffice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DVD")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DirectorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImdbId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImdbRating")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImdbVotes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Metascore")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Plot")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Poster")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Production")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rated")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Released")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Runtime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MoviesDetails");
                });

            modelBuilder.Entity("Movies.API.Models.MovieDetailActor", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ActorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("MovieDetailId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ActorId");

                    b.HasIndex("MovieDetailId");

                    b.ToTable("MovieDetailActors");
                });

            modelBuilder.Entity("Movies.API.Models.MovieDetailCountry", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CountryId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("MovieDetailId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("MovieDetailId");

                    b.ToTable("MovieDetailCountries");
                });

            modelBuilder.Entity("Movies.API.Models.MovieDetailGenre", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("GenreId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MovieDetailId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.HasIndex("MovieDetailId");

                    b.ToTable("MovieDetailGenres");
                });

            modelBuilder.Entity("Movies.API.Models.MovieDetailLanguage", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("LanguageId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MovieDetailId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.HasIndex("MovieDetailId");

                    b.ToTable("MovieDetailLanguages");
                });

            modelBuilder.Entity("Movies.API.Models.MovieDetailWriter", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("MovieDetailId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("WriterId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("MovieDetailId");

                    b.HasIndex("WriterId");

                    b.ToTable("MovieDetailWriters");
                });

            modelBuilder.Entity("Movies.API.Models.Rating", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("MovieDetailId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MovieDetailId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("Movies.API.Models.Writer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Writers");
                });

            modelBuilder.Entity("Movies.API.Models.MovieDetailActor", b =>
                {
                    b.HasOne("Movies.API.Models.Actor", "Actor")
                        .WithMany("ActorMovieDetails")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Movies.API.Models.MovieDetail", "MovieDetail")
                        .WithMany("Actors")
                        .HasForeignKey("MovieDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("MovieDetail");
                });

            modelBuilder.Entity("Movies.API.Models.MovieDetailCountry", b =>
                {
                    b.HasOne("Movies.API.Models.Country", "Country")
                        .WithMany("CountryMovieDetails")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Movies.API.Models.MovieDetail", "MovieDetail")
                        .WithMany("Countries")
                        .HasForeignKey("MovieDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("MovieDetail");
                });

            modelBuilder.Entity("Movies.API.Models.MovieDetailGenre", b =>
                {
                    b.HasOne("Movies.API.Models.Genre", "Genre")
                        .WithMany("GenreMovieDetails")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Movies.API.Models.MovieDetail", "MovieDetail")
                        .WithMany("Genres")
                        .HasForeignKey("MovieDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("MovieDetail");
                });

            modelBuilder.Entity("Movies.API.Models.MovieDetailLanguage", b =>
                {
                    b.HasOne("Movies.API.Models.Language", "Language")
                        .WithMany("LanguageMovieDetails")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Movies.API.Models.MovieDetail", "MovieDetail")
                        .WithMany("Languages")
                        .HasForeignKey("MovieDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");

                    b.Navigation("MovieDetail");
                });

            modelBuilder.Entity("Movies.API.Models.MovieDetailWriter", b =>
                {
                    b.HasOne("Movies.API.Models.MovieDetail", "MovieDetail")
                        .WithMany("Writers")
                        .HasForeignKey("MovieDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Movies.API.Models.Writer", "Writer")
                        .WithMany("WriterMovieDetails")
                        .HasForeignKey("WriterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MovieDetail");

                    b.Navigation("Writer");
                });

            modelBuilder.Entity("Movies.API.Models.Rating", b =>
                {
                    b.HasOne("Movies.API.Models.MovieDetail", "MovieDetail")
                        .WithMany("Ratings")
                        .HasForeignKey("MovieDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MovieDetail");
                });

            modelBuilder.Entity("Movies.API.Models.Actor", b =>
                {
                    b.Navigation("ActorMovieDetails");
                });

            modelBuilder.Entity("Movies.API.Models.Country", b =>
                {
                    b.Navigation("CountryMovieDetails");
                });

            modelBuilder.Entity("Movies.API.Models.Genre", b =>
                {
                    b.Navigation("GenreMovieDetails");
                });

            modelBuilder.Entity("Movies.API.Models.Language", b =>
                {
                    b.Navigation("LanguageMovieDetails");
                });

            modelBuilder.Entity("Movies.API.Models.MovieDetail", b =>
                {
                    b.Navigation("Actors");

                    b.Navigation("Countries");

                    b.Navigation("Genres");

                    b.Navigation("Languages");

                    b.Navigation("Ratings");

                    b.Navigation("Writers");
                });

            modelBuilder.Entity("Movies.API.Models.Writer", b =>
                {
                    b.Navigation("WriterMovieDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
