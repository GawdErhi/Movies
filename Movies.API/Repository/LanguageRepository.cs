using Microsoft.EntityFrameworkCore;
using Movies.API.DB;
using Movies.API.DTOs;
using Movies.API.Models;
using Movies.API.Repository.Contracts;

namespace Movies.API.Repository
{
    public class LanguageRepository : BaseRepository<Language>, ILanguageRepository
    {
        private readonly MoviesAPIDbContext _dbContext;

        public LanguageRepository(MoviesAPIDbContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Saves language record if it doesn't exist, if it exists then it returns the existing record
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<LanguageDTO> TrySaveAsync(string name)
        {
            if (await CountAsync(x => x.Name.ToLower() == name.ToLower()) > 0)
            {
                var existingRecord = await _dbContext.Languages.Where(x => x.Name.ToLower() == name.ToLower()).Select(x => new LanguageDTO { Id = x.Id, Name = x.Name }).SingleOrDefaultAsync();
                return existingRecord;
            }

            var languageRecord = new Language { Id = Guid.NewGuid().ToString(), Name = name };
            Add(languageRecord);

            return new LanguageDTO { Id = languageRecord.Id, Name = languageRecord.Name };
        }
    }
}
