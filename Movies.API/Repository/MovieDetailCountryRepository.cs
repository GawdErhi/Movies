using Movies.API.DB;
using Movies.API.Models;
using Movies.API.Repository.Contracts;

namespace Movies.API.Repository
{
    public class MovieDetailCountryRepository : BaseRepository<MovieDetailCountry>, IMovieDetailCountryRepository
    {
        private readonly MoviesAPIDbContext _dbContext;

        public MovieDetailCountryRepository(MoviesAPIDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
