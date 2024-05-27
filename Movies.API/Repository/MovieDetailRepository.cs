using Microsoft.EntityFrameworkCore;
using Movies.API.DB;
using Movies.API.DTOs;
using Movies.API.Models;
using Movies.API.Repository.Contracts;
using System.Linq;

namespace Movies.API.Repository
{
    public class MovieDetailRepository : BaseRepository<MovieDetail>, IMovieDetailRepository
    {
        private readonly MoviesAPIDbContext _dbContext;

        public MovieDetailRepository(MoviesAPIDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Gets movie with title
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public async Task<MovieDetailDTO> GetMovieByTitle(string title)
        {
            try
            {
                return await _dbContext.MoviesDetails.Where(x => EF.Functions.Like(x.Title, $"%{title}%"))?.Select(x => new MovieDetailDTO
                {
                    Id = x.Id,
                    Title = x.Title,
                    Poster = x.Poster,
                    Rated = x.Rated,
                    Runtime = x.Runtime,
                    Year = x.Year
                }).FirstOrDefaultAsync();
            }
            catch (Exception) { throw; }
        }

        /// <summary>
        /// Gets movie by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<MovieDetailDTO> GetMovieById(string id)
        {
            try
            {
                return await _dbContext.MoviesDetails.Where(x => x.Id == id)
                    .Include(x => x.Ratings)
                    .Include(x => x.Writers)
                    .Include(x => x.Actors)
                    .Include(x => x.Languages)
                    .Include(x => x.Countries)
                    .Select(x => new MovieDetailDTO
                    {
                        Id = x.Id,
                        Title = x.Title,
                        Poster = x.Poster,
                        Rated = x.Rated,
                        Runtime = x.Runtime,
                        Year = x.Year,
                        Plot = x.Plot,
                        Ratings = x.Ratings.Select(x => new RatingDTO { Source = x.Source, Value = x.Value }).ToList(),
                        Writers = x.Writers.Select(x => new WriterDTO { Name = x.Writer.Name }).ToList(),
                        Actors = x.Actors.Select(x => new ActorDTO { Name = x.Actor.Name }).ToList(),
                        SupportedLanguages = x.Languages.Select(x => new LanguageDTO { Name = x.Language.Name }).ToList(),
                        AvailableCountries = x.Countries.Select(x => new CountryDTO { Name = x.Country.Name }).ToList(),
                        Metascore = x.Metascore,
                        ImdbRating = x.ImdbRating,
                        ImdbVotes = x.ImdbVotes,
                        BoxOffice = x.BoxOffice,
                        Production = x.Production,
                        Website = x.Website
                    }).SingleOrDefaultAsync();
            }
            catch (Exception) { throw; }
        }
    }
}
