using Microsoft.EntityFrameworkCore;
using Movies.API.Models;

namespace Movies.API.DB
{
    public class MoviesAPIDbContext : DbContext
    {
        public DbSet<Actor> Actors { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Director> Directors { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<MovieDetail> MoviesDetails { get; set; }

        public DbSet<MovieDetailActor> MovieDetailActors { get; set; }

        public DbSet<MovieDetailCountry> MovieDetailCountries { get; set; }

        public DbSet<MovieDetailGenre> MovieDetailGenres { get; set; }

        public DbSet<MovieDetailLanguage> MovieDetailLanguages { get; set; }

        public DbSet<MovieDetailWriter> MovieDetailWriters { get; set; }

        public DbSet<Rating> Ratings { get; set; }

        public DbSet<Writer> Writers { get; set; }

        public MoviesAPIDbContext(DbContextOptions<MoviesAPIDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Actor>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasIndex(x => x.Name).IsUnique();
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasIndex(x => x.Name).IsUnique();
            });

            modelBuilder.Entity<Director>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasIndex(x => x.Name).IsUnique();
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasIndex(x => x.Name).IsUnique();
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasIndex(x => x.Name).IsUnique();
            });

            modelBuilder.Entity<MovieDetail>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasMany(x => x.Genres).WithOne(x => x.MovieDetail).HasForeignKey(x => x.MovieDetailId);
                entity.HasMany(x => x.Writers).WithOne(x => x.MovieDetail).HasForeignKey(x => x.MovieDetailId);
                entity.HasMany(x => x.Actors).WithOne(x => x.MovieDetail).HasForeignKey(x => x.MovieDetailId);
                entity.HasMany(x => x.Languages).WithOne(x => x.MovieDetail).HasForeignKey(x => x.MovieDetailId);
                entity.HasMany(x => x.Countries).WithOne(x => x.MovieDetail).HasForeignKey(x => x.MovieDetailId);
                entity.HasMany(x => x.Ratings).WithOne(x => x.MovieDetail).HasForeignKey(x => x.MovieDetailId);
            });

            modelBuilder.Entity<MovieDetailActor>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasOne(x => x.MovieDetail).WithMany(x => x.Actors).HasForeignKey(x => x.MovieDetailId);
                entity.HasOne(x => x.Actor).WithMany(x => x.ActorMovieDetails).HasForeignKey(x => x.ActorId);
            });

            modelBuilder.Entity<MovieDetailCountry>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasOne(x => x.MovieDetail).WithMany(x => x.Countries).HasForeignKey(x => x.MovieDetailId);
                entity.HasOne(x => x.Country).WithMany(x => x.CountryMovieDetails).HasForeignKey(x => x.CountryId);
            });

            modelBuilder.Entity<MovieDetailGenre>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasOne(x => x.MovieDetail).WithMany(x => x.Genres).HasForeignKey(x => x.MovieDetailId);
                entity.HasOne(x => x.Genre).WithMany(x => x.GenreMovieDetails).HasForeignKey(x => x.GenreId);
            });

            modelBuilder.Entity<MovieDetailLanguage>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasOne(x => x.MovieDetail).WithMany(x => x.Languages).HasForeignKey(x => x.MovieDetailId);
                entity.HasOne(x => x.Language).WithMany(x => x.LanguageMovieDetails).HasForeignKey(x => x.LanguageId);
            });

            modelBuilder.Entity<MovieDetailWriter>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasOne(x => x.MovieDetail).WithMany(x => x.Writers).HasForeignKey(x => x.MovieDetailId);
                entity.HasOne(x => x.Writer).WithMany(x => x.WriterMovieDetails).HasForeignKey(x => x.WriterId);
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasOne(x => x.MovieDetail).WithMany(x => x.Ratings).HasForeignKey(x => x.MovieDetailId);
            });

            modelBuilder.Entity<Writer>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasIndex(x => x.Name).IsUnique();
                entity.HasMany(x => x.WriterMovieDetails).WithOne(x => x.Writer).HasForeignKey(x => x.WriterId);
            });
        }
    }
}
