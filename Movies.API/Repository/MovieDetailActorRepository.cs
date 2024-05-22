using Movies.API.DB;
using Movies.API.Models;
using Movies.API.Repository.Contracts;

namespace Movies.API.Repository
{
    public class MovieDetailActorRepository : BaseRepository<MovieDetailActor>, IMovieDetailActorRepository
    {
        private readonly MoviesAPIDbContext _dbContext;

        public MovieDetailActorRepository(MoviesAPIDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
