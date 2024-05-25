using Movies.API.DTOs;
using Movies.API.Models;

namespace Movies.API.Repository.Contracts
{
    public interface IMovieDetailRepository : IBaseRepository<MovieDetail>
    {
        /// <summary>
        /// Gets movie with title
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        Task<MovieDetailDTO> GetMovieByTitle(string title);

        /// <summary>
        /// Gets movie by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<MovieDetailDTO> GetMovieById(string id);
    }
}
