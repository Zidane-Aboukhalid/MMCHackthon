﻿using Domain.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly DBContext context;
    public GenericRepository(DBContext context)
    {
        this.context = context;
    }
    public void Add(T entity)
    {
        context.Set<T>().Add(entity);
    }
    public void AddRange(IEnumerable<T> entities)
    {
        context.Set<T>().AddRange(entities);
    }
    public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
    {
        return context.Set<T>().Where(expression);
    }
    public IEnumerable<T> GetAll()
    {
        return context.Set<T>().ToList();
    }
    public T GetById(Guid id)
    {
        return context.Set<T>().Find(id);
    }
    public void Remove(T entity)
    {
        context.Set<T>().Remove(entity);
    }
    public void RemoveRange(IEnumerable<T> entities)
    {
        context.Set<T>().RemoveRange(entities);
    }
}