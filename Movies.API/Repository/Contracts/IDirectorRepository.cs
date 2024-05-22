using Movies.API.DTOs;
using Movies.API.Models;
namespace Movies.API.Repository.Contracts
{
    public interface IDirectorRepository : IBaseRepository<Director>
    {
        /// <summary>
        /// Saves director record if it doesn't exist, if it exists then it returns the existing record
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<DirectorDTO> TrySaveAsync(string name);
    }
}
