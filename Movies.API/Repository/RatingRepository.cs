using Movies.API.DB;
using Movies.API.Models;
using Movies.API.Repository.Contracts;

namespace Movies.API.Repository
{
    public class RatingRepository : BaseRepository<Rating>, IRatingRepository
    {
        private readonly MoviesAPIDbContext _dbContext;

        public RatingRepository(MoviesAPIDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
