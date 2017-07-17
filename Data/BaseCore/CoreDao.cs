using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Repository;
using System.Data;
using NHibernate;
using NHibernate.Linq;

namespace Data.BaseCore
{
    public abstract class CoreDao<T, IdT> : IGenericDao<T, IdT> where T : EntityObject<IdT>
    {
        protected IDbConnection SqlConnection
        {
            get
            {
                return DataApplication.OpenConnection();
            }
        }

        protected ISession CurrentSession
        {
            get
            {
                return NHibernateApplication.CurrentSession;
            }
        }

        /// <summary>
        /// NHibernate queryable for entities
        /// </summary>
        protected IQueryable<T> EntityQuery
        {
            get
            {
                if (NHibernateApplication.QueryCache)
                {
                    return CurrentSession.Query<T>().Cacheable().CacheRegion(typeof(T).FullName);
                }
                else
                {
                    return CurrentSession.Query<T>();
                }
            }
        }

        /// <summary>
        /// NHibernate query over for entities
        /// </summary>
        protected IQueryOver<T, T> OverQuery
        {
            get { return CurrentSession.QueryOver<T>(); }
        }

        /// <summary>
        /// Load entity by id
        /// </summary>
        /// <param name="Id">Indentify</param>
        /// <param name="shouldLock">Should lock</param>
        /// <returns>Entity</returns>
        public virtual T LoadById(IdT Id, bool shouldLock)
        {
            if (shouldLock)
            {
                return CurrentSession.Load<T>(Id, LockMode.Read);
            }
            else
            {
                return CurrentSession.Load<T>(Id, LockMode.None);
            }
        }

        /// <summary>
        /// Load entity by id
        /// </summary>
        /// <param name="Id">Indentify</param>
        /// <returns>Entity</returns>
        public virtual T LoadById(IdT Id)
        {
            return CurrentSession.Load<T>(Id);
        }

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="Id">Indentify</param>
        /// <param name="shouldLock">Should lock</param>
        /// <returns>Entity</returns>
        public virtual T GetById(IdT Id, bool shouldLock)
        {
            if (shouldLock)
            {
                return CurrentSession.Get<T>(Id, LockMode.Read);
            }
            else
            {
                return CurrentSession.Get<T>(Id);
            }
        }

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="Id">Indentify</param>
        /// <returns>Entity</returns>
        public virtual T GetById(IdT Id)
        {
            var entity = CurrentSession.Get<T>(Id);
            EvictQueries();
            return entity;
        }


        public T Get(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Fetch(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IList<T> List(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Fetch(System.Linq.Expressions.Expression<Func<T, bool>> predicate, int offset, int limit)
        {
            throw new NotImplementedException();
        }

        public IList<T> List(System.Linq.Expressions.Expression<Func<T, bool>> predicate, int offset, int limit)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Fetch(System.Linq.Expressions.Expression<Func<T, bool>> predicate, Action<Linq.Orderable<T>> order)
        {
            throw new NotImplementedException();
        }

        public IList<T> List(System.Linq.Expressions.Expression<Func<T, bool>> predicate, Action<Linq.Orderable<T>> order)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Fetch(System.Linq.Expressions.Expression<Func<T, bool>> predicate, Action<Linq.Orderable<T>> order, int offset, int limit)
        {
            throw new NotImplementedException();
        }

        public IList<T> List(System.Linq.Expressions.Expression<Func<T, bool>> predicate, Action<Linq.Orderable<T>> order, int offset, int limit)
        {
            throw new NotImplementedException();
        }

        public int Count(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IList<T> ListAll()
        {
            throw new NotImplementedException();
        }

        public IList<T> ListAll(int offset, int limit)
        {
            throw new NotImplementedException();
        }

        public int CountAll()
        {
            throw new NotImplementedException();
        }

        public T Save(T entity)
        {
            throw new NotImplementedException();
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }

        public IGenericDao<T, IdT> Copy(T source, T target)
        {
            throw new NotImplementedException();
        }

        public IGenericDao<T, IdT> Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public IGenericDao<T, IdT> Delete(string query)
        {
            throw new NotImplementedException();
        }

        public IGenericDao<T, IdT> Delete(IdT id)
        {
            throw new NotImplementedException();
        }

        public IGenericDao<T, IdT> Delete(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IGenericDao<T, IdT> EvictQueries(Type entityType)
        {
            throw new NotImplementedException();
        }

        public IGenericDao<T, IdT> EvictQueries()
        {
            throw new NotImplementedException();
        }
    }
}
