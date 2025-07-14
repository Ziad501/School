using Application.Features;
using Application.Interfaces;
using Domain.Abstractions;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class QueryRepository<T>(AppDbContext _context) : IQueryRepository<T> where T : BaseEntity
    {
        protected readonly DbSet<T> _dbset = _context.Set<T>();

        public async Task<ResultT<bool>> AnyAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken cancellationToken = default)
        {
            if(predicate is null)
                return await _dbset.AnyAsync(cancellationToken);
            return await _dbset.AnyAsync(predicate, cancellationToken);
        }

        public async Task<ResultT<int>> CountAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken cancellationToken = default)
        {
            if (predicate is null)
                return await _dbset.CountAsync(cancellationToken);
            return await _dbset.CountAsync(predicate, cancellationToken);

        }

        public async Task<ResultT<T>> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IQueryable<T>>? includes = null, CancellationToken cancellationToken = default)
        {
            IQueryable<T> query = _dbset;
            if (includes is not null)
                query = includes(query);
            var entity = await query.FirstOrDefaultAsync(predicate, cancellationToken);
            if (entity is null)
                return Errors.NotFound;
            return entity;
        }

        public async Task<ResultT<TResult>> FirstOrDefaultAsync<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector, CancellationToken cancellationToken = default)
        {
            var result = await _dbset.
                Where(predicate).
                Select(selector).
                FirstOrDefaultAsync(cancellationToken);
            if(result is null) 
                return Errors.NotFound;
            return result;

        }

        public async Task<ResultT<T>> GetByIdAsync(Guid id, Func<IQueryable<T>, IQueryable<T>>? includes = null, CancellationToken cancellationToken = default)
        {
            IQueryable<T> query = _dbset;
            if(includes is not null) 
                query = includes(query);
            var entity = await query.FirstOrDefaultAsync(p=>p.Id == id,cancellationToken);
            if(entity is null)
                return Errors.NotFound;
            return entity;
        }

        public async Task<ResultT<PagedList<T>>> GetPagedAsync(int page, int pageSize, CancellationToken cancellationToken = default)
        {
            var pagedList = await PagedList<T>.CreateAsync(_dbset.AsNoTracking(), page, pageSize, cancellationToken);
            if(pagedList is null) 
                return Errors.NotFound;
            return pagedList;
        }

        public async Task<ResultT<PagedList<T>>> GetPagedAsync(Expression<Func<T, bool>> predicate, int page, int pageSize, Func<IQueryable<T>, IQueryable<T>>? includes = null, CancellationToken cancellationToken = default)
        {
            IQueryable<T> query = _dbset.AsNoTracking();
            if(includes is not null)
                query = includes(query);
            query = query.Where(predicate);
            var pagedList = await PagedList<T>.CreateAsync(query, page, pageSize, cancellationToken);
            if (pagedList is null) 
                return Errors.NotFound;
            return pagedList;
        }

        public async Task<ResultT<PagedList<TResult>>> GetPagedAsync<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector, int page, int pageSize, CancellationToken cancellationToken = default)
        {
            var query = _dbset.AsNoTracking()
                .Where(predicate)
                .Select(selector);
            var pagedList = await PagedList<TResult>.CreateAsync(query, page, pageSize, cancellationToken);
            if (pagedList is null)
                return Errors.NotFound;
            return pagedList;
        }

        public IQueryable<T> GetTableAsTracking()
        {
            return _dbset;
        }

        public IQueryable<T> GetTableNoTracking()
        {
            return _dbset.AsNoTracking();
        }
    }
}