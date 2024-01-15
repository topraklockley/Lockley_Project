﻿using Lockley.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lockley.BL
{
    public class SQLRepository<T> : IRepository<T> where T : class
    {
        SQLContext db;

        public SQLRepository(SQLContext _db)
        {
            db = _db;
        }

        public IQueryable<T> GetAll()
        {
            return db.Set<T>();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return db.Set<T>().Where(expression);
        }

        public T GetBy(Expression<Func<T, bool>> expression)
        {
            return db.Set<T>().FirstOrDefault(expression);
        }

        public void Add(T entity)
        {
            db.Set<T>().Add(entity);
            db.SaveChanges();
        }

        public void Update(T entity)
        {
            db.Update(entity);
            db.SaveChanges();
        }

        public void Delete(T entity)
        {
            db.Remove(entity);
            db.SaveChanges();
        }
    }
}
