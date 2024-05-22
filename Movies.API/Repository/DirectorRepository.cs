using Microsoft.EntityFrameworkCore;
using Movies.API.DB;
using Movies.API.DTOs;
using Movies.API.Models;
using Movies.API.Repository.Contracts;

namespace Movies.API.Repository
{
    public class DirectorRepository : BaseRepository<Director>, IDirectorRepository
    {
        private readonly MoviesAPIDbContext _dbContext;

        public DirectorRepository(MoviesAPIDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Saves director record if it doesn't exist, if it exists then it returns the existing record
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<DirectorDTO> TrySaveAsync(string name)
        {
            if(await CountAsync(x => x.Name.ToLower() == name.ToLower()) > 0)
            {
                var existingRecord = await _dbContext.Directors.Where(x => x.Name.ToLower() == name.ToLower()).Select(x => new DirectorDTO { Id = x.Id, Name = x.Name }).SingleOrDefaultAsync();
                return existingRecord;
            }

            var directorRecord = new Director { Id = Guid.NewGuid().ToString(), Name = name };
            Add(directorRecord);

            return new DirectorDTO { Id = directorRecord.Id, Name = directorRecord.Name };
        }
    }
}
