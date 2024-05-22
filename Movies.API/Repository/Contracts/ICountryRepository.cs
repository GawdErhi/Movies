using Movies.API.DTOs;
using Movies.API.Models;

namespace Movies.API.Repository.Contracts
{
    public interface ICountryRepository : IBaseRepository<Country>
    {
        /// <summary>
        /// Saves country record if it doesn't exist, if it exists then it returns the existing record
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<CountryDTO> TrySaveAsync(string name);
    }
}
