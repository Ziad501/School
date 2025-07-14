using Application.Features;
using Domain.Abstractions;
using Domain.Entities;
using System.Linq.Expressions;

namespace Application.Interfaces
{
    public interface IQueryRepository<T> where T : BaseEntity
    {
        Task<ResultT<T>> GetByIdAsync(
            Guid id,
            Func<IQueryable<T>, IQueryable<T>>? includes = null,
            CancellationToken cancellationToken = default);
        Task<ResultT<T>> FirstOrDefaultAsync(
            Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IQueryable<T>>? includes = null,
            CancellationToken cancellationToken = default);
        Task<ResultT<TResult>> FirstOrDefaultAsync<TResult>(
            Expression<Func<T, bool>> predicate,
            Expression<Func<T, TResult>> selector,
            CancellationToken cancellationToken = default);
        Task<ResultT<int>> CountAsync(
            Expression<Func<T, bool>>? predicate = null,
            CancellationToken cancellationToken = default);
        Task<ResultT<bool>> AnyAsync(
            Expression<Func<T, bool>>? predicate = null,
            CancellationToken cancellationToken = default);
        IQueryable<T> GetTableNoTracking();
        IQueryable<T> GetTableAsTracking();
        Task<ResultT<PagedList<T>>> GetPagedAsync(
            int page, 
            int pageSize,
            CancellationToken cancellationToken = default);
        Task<ResultT<PagedList<T>>> GetPagedAsync(
            Expression<Func<T, bool>> predicate,
            int page, 
            int pageSize,
            Func<IQueryable<T>, IQueryable<T>>? includes = null,
            CancellationToken cancellationToken = default);

        Task<ResultT<PagedList<TResult>>> GetPagedAsync<TResult>(
            Expression<Func<T, bool>> predicate,
            Expression<Func<T, TResult>> selector,
            int page, int pageSize, CancellationToken cancellationToken = default);
    }
}