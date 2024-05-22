using Microsoft.EntityFrameworkCore;
using Movies.API.DB;
using Movies.API.DTOs;
using Movies.API.Models;
using Movies.API.Repository.Contracts;

namespace Movies.API.Repository
{
    public class WriterRepository : BaseRepository<Writer>, IWriterRepository
    {
        private readonly MoviesAPIDbContext _dbContext;

        public WriterRepository(MoviesAPIDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Saves writer record if it doesn't exist, if it exists then it returns the existing record
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<WriterDTO> TrySaveAsync(string name)
        {
            if (await CountAsync(x => x.Name.ToLower() == name.ToLower()) > 0)
            {
                var existingRecord = await _dbContext.Writers.Where(x => x.Name.ToLower() == name.ToLower()).Select(x => new WriterDTO { Id = x.Id, Name = x.Name }).SingleOrDefaultAsync();
                return existingRecord;
            }

            var writerRecord = new Writer { Id = Guid.NewGuid().ToString(), Name = name };
            Add(writerRecord);

            return new WriterDTO { Id = writerRecord.Id, Name = writerRecord.Name };
        }
    }
}
