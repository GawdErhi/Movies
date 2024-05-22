using Movies.API.DB;
using Movies.API.Models;
using Movies.API.Repository.Contracts;

namespace Movies.API.Repository
{
    public class MovieDetailWriterRepository : BaseRepository<MovieDetailWriter>, IMovieDetailWriterRepository
    {
        private readonly MoviesAPIDbContext _dbContext;

        public MovieDetailWriterRepository(MoviesAPIDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
