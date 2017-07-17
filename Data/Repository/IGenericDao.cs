using Data.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface IGenericDao<T, IdT>
    {
        /// <summary>
        /// Load intity by id
        /// </summary>
        /// <param name="Id">Indentify</param>
        /// <param name="shouldLock">Should lock</param>
        /// <returns>Entity</returns>
        T LoadById(IdT Id, bool shouldLock);

        /// <summary>
        /// Load intity by id
        /// </summary>
        /// <param name="Id">Indentify</param>
        /// <returns>Entity</returns>
        T LoadById(IdT Id);

        /// <summary>
        /// Get intity by id
        /// </summary>
        /// <param name="Id">Indentify</param>
        /// <param name="shouldLock">Should lock</param>
        /// <returns>Entity</returns>
        T GetById(IdT Id, bool shouldLock);

        /// <summary>
        /// Get intity by id
        /// </summary>
        /// <param name="Id">Indentify</param>
        /// <returns>Entity</returns>
        T GetById(IdT Id);

        /// <summary>
        /// Get intity by expression
        /// </summary>
        /// <param name="predicate">Predicate expression</param>
        /// <returns>Entity</returns>
        T Get(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Fetch entity queryable
        /// </summary>
        /// <param name="predicate">Predicate expression</param>
        /// <returns>Queryable instance</returns>
        IQueryable<T> Fetch(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// List entities by expression
        /// </summary>
        /// <param name="predicate">Predicate expression</param>
        /// <returns>A list of entities</returns>
        IList<T> List(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Fetch entity queryable
        /// </summary>
        /// <param name="predicate">Predicate expression</param>
        /// <param name="offset">The first result to be retrieved</param>
        /// <param name="limit">The limit upon the number of objects to be retrieved</param>
        /// <returns>Queryable instance</returns>
        IQueryable<T> Fetch(Expression<Func<T, bool>> predicate, int offset, int limit);

        /// <summary>
        /// List entities by expression
        /// </summary>
        /// <param name="predicate">Predicate expression</param>
        /// <param name="offset">The first result to be retrieved</param>
        /// <param name="limit">The limit upon the number of objects to be retrieved</param>
        /// <returns>A list of entities</returns>
        IList<T> List(Expression<Func<T, bool>> predicate, int offset, int limit);

        /// <summary>
        /// Fetch entity queryable
        /// </summary>
        /// <param name="predicate">Predicate expression</param>
        /// <param name="order">Order expression</param>
        /// <returns>Queryable instance</returns>
        IQueryable<T> Fetch(Expression<Func<T, bool>> predicate, Action<Orderable<T>> order);

        /// <summary>
        /// List entities by expression
        /// </summary>
        /// <param name="predicate">Predicate expression</param>
        /// <param name="order">Order expression</param>
        /// <returns>A list of entities</returns>
        IList<T> List(Expression<Func<T, bool>> predicate, Action<Orderable<T>> order);

        /// <summary>
        /// Fetch entity queryable
        /// </summary>
        /// <param name="predicate">Predicate expression</param>
        /// <param name="order">Order expression</param>
        /// <param name="offset">The first result to be retrieved</param>
        /// <param name="limit">The limit upon the number of objects to be retrieved</param>
        /// <returns>Queryable instance</returns>
        IQueryable<T> Fetch(Expression<Func<T, bool>> predicate, Action<Orderable<T>> order, int offset, int limit);

        /// <summary>
        /// List entities by expression
        /// </summary>
        /// <param name="predicate">Predicate expression</param>
        /// <param name="order">Order expression</param>
        /// <param name="offset">The first result to be retrieved</param>
        /// <param name="limit">The limit upon the number of objects to be retrieved</param>
        /// <returns>A list of entities</returns>
        IList<T> List(Expression<Func<T, bool>> predicate, Action<Orderable<T>> order, int offset, int limit);

        /// <summary>
        /// Count entities
        /// </summary>
        /// <param name="predicate">Predicate expression</param>
        /// <returns>Number of entities</returns>
        int Count(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// List all entities
        /// </summary>
        /// <returns>List of entities</returns>
        IList<T> ListAll();

        /// <summary>
        /// List all entities
        /// </summary>
        /// <param name="offset">The first result to be retrieved</param>
        /// <param name="limit">The limit upon the number of objects to be retrieved</param>
        /// <returns>List of entities</returns>
        IList<T> ListAll(int offset, int limit);

        /// <summary>
        /// Count all entities
        /// </summary>
        /// <returns>Number of entities</returns>
        int CountAll();

        /// <summary>
        /// Save an entity
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Entity</returns>
        T Save(T entity);

        /// <summary>
        /// Update an entity
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Entity</returns>
        T Update(T entity);

        /// <summary>
        /// Copy entity
        /// </summary>
        /// <param name="source">Source entity</param>
        /// <param name="target">Target entity</param>
        IGenericDao<T, IdT> Copy(T source, T target);

        /// <summary>
        /// Delete an entity
        /// </summary>
        /// <param name="entity">Entity</param>
        IGenericDao<T, IdT> Delete(T entity);

        /// <summary>
        /// Delete by query
        /// </summary>
        /// <param name="query">query</param>
        IGenericDao<T, IdT> Delete(string query);

        /// <summary>
        /// Delete an entity
        /// </summary>
        /// <param name="entity">Entity</param>
        IGenericDao<T, IdT> Delete(IdT id);

        /// <summary>
        /// Delete entities by expression
        /// </summary>
        /// <param name="predicate">Predicate expression</param>
        IGenericDao<T, IdT> Delete(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Evic queries
        /// </summary>
        /// <param name="entityType">Entity type</param>
        IGenericDao<T, IdT> EvictQueries(Type entityType);

        /// <summary>
        /// Evic queries
        /// </summary>
        IGenericDao<T, IdT> EvictQueries();
    }
}
