﻿using Application.Interfaces.Generic;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories.Genereic;

public class GenericRepository<T>(AppDbContext _context) : IGenericRepository<T> where T : BaseEntity
{
    protected DbSet<T> _dbSet = _context.Set<T>();
    public virtual async Task<T> GetByIdAsync(Guid id, CancellationToken cancellation)
    {

        return await _dbSet.FindAsync(id, cancellation);
    }


    public IQueryable<T> GetTableNoTracking()
    {
        return _dbSet.AsNoTracking().AsQueryable();
    }


    public virtual async Task AddRangeAsync(ICollection<T> entities)
    {
        await _dbSet.AddRangeAsync(entities);
        await _context.SaveChangesAsync();

    }
    public virtual async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync();

        return entity;
    }

    public virtual async Task UpdateAsync(T entity)
    {
        _dbSet.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();

    }

    public virtual async Task DeleteAsync(T entity, CancellationToken cancellation)
    {
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync(cancellation);
    }
    public virtual async Task DeleteRangeAsync(ICollection<T> entities)
    {
        foreach (var entity in entities)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }
        await _context.SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }


    public IQueryable<T> GetTableAsTracking()
    {
        return _dbSet.AsQueryable();

    }

    public virtual async Task UpdateRangeAsync(ICollection<T> entities)
    {
        _dbSet.UpdateRange(entities);
        await _context.SaveChangesAsync();
    }

    public async Task<T?> GetAsync(Expression<Func<T, bool>>? filter, Func<IQueryable<T>, IQueryable<T>>? include = null, CancellationToken cancellationToken = default)
    {
        IQueryable<T> query = _dbSet.AsNoTracking();
        if (include is not null)
            query = include(query);
        if (filter is not null)
            query = query.Where(filter);

        return await query.FirstOrDefaultAsync(cancellationToken);
    }
}

