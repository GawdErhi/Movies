using Microsoft.EntityFrameworkCore;
using Movies.API.DB;
using Movies.API.DTOs;
using Movies.API.Models;
using Movies.API.Repository.Contracts;

namespace Movies.API.Repository
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        private readonly MoviesAPIDbContext _dbContext;

        public CountryRepository(MoviesAPIDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Saves country record if it doesn't exist, if it exists then it returns the existing record
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<CountryDTO> TrySaveAsync(string name)
        {
            if (await CountAsync(x => x.Name.ToLower() == name.ToLower()) > 0)
            {
                var existingRecord = await _dbContext.Countries.Where(x => x.Name.ToLower() == name.ToLower()).Select(x => new CountryDTO { Id = x.Id, Name = x.Name }).SingleOrDefaultAsync();
                return existingRecord;
            }

            var countryRecord = new Country { Id = Guid.NewGuid().ToString(), Name = name };
            Add(countryRecord);

            return new CountryDTO { Id = countryRecord.Id, Name = countryRecord.Name };
        }
    }
}
