using Movies.API.DTOs;

namespace Movies.API.Services.Contracts
{
    public interface IOMDBService
    {
        /// <summary>
        /// searches for movie with title
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        Task<dynamic> SearchMovie(string title);

        /// <summary>
        /// Gets movie by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<MovieDetailDTO> GetMovie(string id);
    }
}
