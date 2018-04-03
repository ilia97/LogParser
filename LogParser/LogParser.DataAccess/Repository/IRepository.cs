﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LogParser.DataAccess.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IList<TEntity>> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        Task<TEntity> GetById(object id);

        void Insert(TEntity entity);

        void Delete(object id);

        void Delete(TEntity entityToDelete);

        void Update(TEntity entityToUpdate);
    }
}