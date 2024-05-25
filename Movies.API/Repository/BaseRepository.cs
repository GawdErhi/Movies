using Microsoft.EntityFrameworkCore;
using Movies.API.DB;
using Movies.API.Models;
using System.Linq.Expressions;

namespace Movies.API.Repository
{
    public abstract class BaseRepository<T> where T : BaseModel
    {
        private readonly MoviesAPIDbContext _dbContext;
        protected BaseRepository(MoviesAPIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Starts a new transaction
        /// </summary>
        public void CreateTransaction()
        {
            try
            {
                _dbContext.Database.BeginTransaction();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Adds an item to the database entity
        /// </summary>
        /// <param name="model"></param>
        public T Add(T model)
        {
            try
            {
                _dbContext.Add(model);
                return model;
            }
            catch (Exception)
            {
                Rollback();
                throw;
            }
        }

        /// <summary>
        /// Adds and saves an item to the database entity
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Save(T model)
        {
            try
            {
                _dbContext.Add(model);
                return _dbContext.SaveChanges() > 0;
            }
            catch (Exception)
            {
                Rollback();
                throw;
            }
        }

        /// <summary>
        /// Adds and saves a collections of items to the database entity
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public bool SaveBundle(IEnumerable<T> models)
        {
            try
            {
                _dbContext.AddRange(models);
                return _dbContext.SaveChanges() > 0;
            }
            catch (Exception)
            {
                Rollback();
                throw;
            }
        }

        /// <summary>
        /// Commits an ongoing transaction
        /// </summary>
        public void CommitTransaction()
        {
            try
            {
                _dbContext.Database.CommitTransaction();
            }
            catch (Exception)
            {
                Rollback();
                throw;
            }
        }

        /// <summary>
        /// Gets entity with id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Get(int id)
        {
            try
            {
                return _dbContext.Find<T>(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Updates entity
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(T model)
        {
            try
            {
                _dbContext.Update(model);
                return _dbContext.SaveChanges() > 0;
            }
            catch (Exception)
            {
                Rollback();
                throw;
            }
        }

        /// <summary>
        /// Rolls back current db transaction
        /// </summary>
        public void Rollback()
        {
            try
            {
                if (_dbContext.Database.CurrentTransaction != null) { _dbContext.Database.RollbackTransaction(); }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Returns item count for lambda
        /// </summary>
        /// <param name="lambda"></param>
        /// <returns></returns>
        public async Task<long> CountAsync(Expression<Func<T, bool>> lambda)
        {
            try
            {
                return await _dbContext.Set<T>().LongCountAsync(lambda);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Returns item count for lambda
        /// </summary>
        /// <param name="lambda"></param>
        /// <returns></returns>
        public async Task<long> CountAsync()
        {
            try
            {
                return await _dbContext.Set<T>().LongCountAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Saves changes
        /// </summary>
        /// <returns></returns>
        public async Task SaveChangesAsync()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                Rollback();
                throw;
            }
        }
    }
}
