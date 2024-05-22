using Movies.API.DB;
using Movies.API.Models;
using Movies.API.Repository.Contracts;

namespace Movies.API.Repository
{
    public class MovieDetailGenreRepository : BaseRepository<MovieDetailGenre>, IMovieDetailGenreRepository
    {
        private readonly MoviesAPIDbContext _dbContext;

        public MovieDetailGenreRepository(MoviesAPIDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
