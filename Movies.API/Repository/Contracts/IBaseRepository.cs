using Movies.API.Models;
using System.Linq.Expressions;

namespace Movies.API.Repository.Contracts
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        /// <summary>
        /// Starts a new transaction
        /// </summary>
        void CreateTransaction();

        /// <summary>
        /// Adds an item to the database entity
        /// </summary>
        /// <param name="model"></param>
        T Add(T model);

        /// <summary>
        /// Adds and saves an item to the database entity
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Save(T model);

        /// <summary>
        /// Adds and saves a collections of items to the database entity
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        bool SaveBundle(IEnumerable<T> models);

        /// <summary>
        /// Commits an ongoing transaction
        /// </summary>
        void CommitTransaction();

        /// <summary>
        /// Gets entity with id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get(int id);

        /// <summary>
        /// Updates entity
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Update(T model);

        /// <summary>
        /// Rolls back current db transaction
        /// </summary>
        void Rollback();

        /// <summary>
        /// Returns item count for lambda
        /// </summary>
        /// <param name="lambda"></param>
        /// <returns></returns>
        Task<long> CountAsync(Expression<Func<T, bool>> lambda);

        /// <summary>
        /// Returns item count for lambda
        /// </summary>
        /// <param name="lambda"></param>
        /// <returns></returns>
        Task<long> CountAsync();
    }
}
