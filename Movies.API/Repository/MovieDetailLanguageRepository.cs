using Movies.API.DB;
using Movies.API.Models;
using Movies.API.Repository.Contracts;

namespace Movies.API.Repository
{
    public class MovieDetailLanguageRepository : BaseRepository<MovieDetailLanguage>, IMovieDetailLanguageRepository
    {
        private readonly MoviesAPIDbContext _dbContext;

        public MovieDetailLanguageRepository(MoviesAPIDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
