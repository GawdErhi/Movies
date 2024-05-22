using Movies.API.DB;
using Movies.API.Models;
using Movies.API.Repository.Contracts;

namespace Movies.API.Repository
{
    public class MovieDetailRepository : BaseRepository<MovieDetail>, IMovieDetailRepository
    {
        private readonly MoviesAPIDbContext _dbContext;

        public MovieDetailRepository(MoviesAPIDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
