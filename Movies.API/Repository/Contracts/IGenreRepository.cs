using Movies.API.DTOs;
using Movies.API.Models;

namespace Movies.API.Repository.Contracts
{
    public interface IGenreRepository : IBaseRepository<Genre>
    {
        /// <summary>
        /// Saves genre record if it doesn't exist, if it exists then it returns the existing record
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<GenreDTO> TrySaveAsync(string name);
    }
}
