using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Movies.API.DB;
using Movies.API.Extensions;
using Movies.API.Repository;
using Movies.API.Repository.Contracts;
using Movies.API.Services;
using Movies.API.Services.Contracts;
using Movies.API.Settings;
using Movies.API.Settings.Contracts;
using System.Configuration;

namespace Movies.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<MoviesAPIDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

            builder.Services.Configure<OMDBAPIClientSettings>(builder.Configuration.GetSection(OMDBAPIClientSettings.NAME));
            builder.Services.TryAddSingleton<IOMDBAPIClientSettings>(x => x.GetRequiredService<IOptions<OMDBAPIClientSettings>>().Value);

            builder.Services.TryAddScoped<IMovieDetailRepository, MovieDetailRepository>();
            builder.Services.TryAddScoped<IActorRepository, ActorRepository>();
            builder.Services.TryAddScoped<ICountryRepository, CountryRepository>();
            builder.Services.TryAddScoped<IDirectorRepository, DirectorRepository>();
            builder.Services.TryAddScoped<IGenreRepository, GenreRepository>();
            builder.Services.TryAddScoped<ILanguageRepository, LanguageRepository>();
            builder.Services.TryAddScoped<IMovieDetailActorRepository, MovieDetailActorRepository>();
            builder.Services.TryAddScoped<IMovieDetailCountryRepository, MovieDetailCountryRepository>();
            builder.Services.TryAddScoped<IMovieDetailGenreRepository, MovieDetailGenreRepository>();
            builder.Services.TryAddScoped<IMovieDetailLanguageRepository, MovieDetailLanguageRepository>();
            builder.Services.TryAddScoped<IMovieDetailWriterRepository, MovieDetailWriterRepository>();
            builder.Services.TryAddScoped<IRatingRepository, RatingRepository>();
            builder.Services.TryAddScoped<IWriterRepository, WriterRepository>();

            builder.Services.AddHttpClient(OMDBAPIClientSettings.NAME, client =>
            {
                client.BaseAddress = new Uri(builder.Configuration.GetSection("OMDBAPIClient").GetValue<string>("BaseURL"));
            });
            builder.Services.AddHttpClient();
            builder.Services.TryAddScoped<IOMDBService, OMDBService>();

            builder.Services.AddLog4NetLogger();
            builder.Services.AddControllers();

            builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
                options.SuppressMapClientErrors = true;
            });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI();
            app.MapControllers();

            app.Run();
        }
    }
}
