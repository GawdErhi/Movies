using Microsoft.EntityFrameworkCore;
using Movies.API.DB;
using Movies.API.DTOs;
using Movies.API.Models;
using Movies.API.Repository.Contracts;

namespace Movies.API.Repository
{
    public class ActorRepository : BaseRepository<Actor>, IActorRepository
    {
        private readonly MoviesAPIDbContext _dbContext;
        public ActorRepository(MoviesAPIDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Saves actor record if it doesn't exist, if it exists then it returns the existing record
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<ActorDTO> TrySaveAsync(string name)
        {
            if (await CountAsync(x => x.Name.ToLower() == name.ToLower()) > 0)
            {
                var existingRecord = await _dbContext.Actors.Where(x => x.Name.ToLower() == name.ToLower()).Select(x => new ActorDTO { Id = x.Id, Name = x.Name }).SingleOrDefaultAsync();
                return existingRecord;
            }

            var actorRecord = new Actor { Id = Guid.NewGuid().ToString(), Name = name };
            Add(actorRecord);

            return new ActorDTO { Id = actorRecord.Id, Name = actorRecord.Name };
        }
    }
}
