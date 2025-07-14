using Domain.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage;

namespace Application.Interfaces
{
    public interface ICommandRepository<T> where T : BaseEntity
    {
        Task<ResultT<T>> AddAsync(T entity,CancellationToken cancellation = default);
        Task<Result> AddRangeAsync(ICollection<T> entities, CancellationToken cancellation = default);
        Result Update(T entity);
        Result UpdateRange(ICollection<T> entities);
        Result Delete(T entity);
        Result DeleteRange(ICollection<T> entities);
        Task<Result> SaveChangesAsync(CancellationToken cancellation = default);
        ResultT<IDbContextTransaction> BeginTransaction();
        Task<ResultT<IDbContextTransaction>> BeginTransactionAsync(CancellationToken cancellation = default);
        Result Commit();
        Task<Result> CommitAsync(CancellationToken cancellation = default);
        Result RollBack();
        Task<Result> RollBackAsync(CancellationToken cancellation = default);
        Task<Result> BulkInsertAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
    }
}

