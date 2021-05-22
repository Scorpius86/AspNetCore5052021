﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Net5.Fundamentals.EF.CodeFirst.Data.Repositories.Base
{
    public interface IGenericRepository<TEntity> where TEntity:class
    {
        void Delete(Object id);
        void Delete(TEntity entityToDelete);
        List<TEntity> GetAll(
            Expression<Func<TEntity, bool>> filter = null, 
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, 
            string includeProperties = "");
        TEntity GetById(object id);
        void Insert(TEntity entity);
        void Update(TEntity entityToupdate);
    }
}
