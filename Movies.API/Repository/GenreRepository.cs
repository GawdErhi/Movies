using Microsoft.EntityFrameworkCore;
using Movies.API.DB;
using Movies.API.DTOs;
using Movies.API.Models;
using Movies.API.Repository.Contracts;

namespace Movies.API.Repository
{
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        private readonly MoviesAPIDbContext _dbContext;

        public GenreRepository(MoviesAPIDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Saves genre record if it doesn't exist, if it exists then it returns the existing record
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<GenreDTO> TrySaveAsync(string name)
        {
            if (await CountAsync(x => x.Name.ToLower() == name.ToLower()) > 0)
            {
                var existingRecord = await _dbContext.Genres.Where(x => x.Name.ToLower() == name.ToLower()).Select(x => new GenreDTO { Id = x.Id, Name = x.Name }).SingleOrDefaultAsync();
                return existingRecord;
            }

            var genreRecord = new Genre { Id = Guid.NewGuid().ToString(), Name = name };
            Add(genreRecord);

            return new GenreDTO { Id = genreRecord.Id, Name = genreRecord.Name };
        }
    }
}
