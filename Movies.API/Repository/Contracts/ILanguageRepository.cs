using Movies.API.DTOs;
using Movies.API.Models;

namespace Movies.API.Repository.Contracts
{
    public interface ILanguageRepository : IBaseRepository<Language>
    {
        /// <summary>
        /// Saves language record if it doesn't exist, if it exists then it returns the existing record
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<LanguageDTO> TrySaveAsync(string name);
    }
}
