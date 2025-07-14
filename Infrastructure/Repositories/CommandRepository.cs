using Application.Interfaces;
using Domain.Abstractions;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using EFCore.BulkExtensions;


namespace Infrastructure.Repositories
{
    public class CommandRepository<T>(AppDbContext _context) : ICommandRepository<T> where T : BaseEntity
    {
        protected DbSet<T> _DbSet = _context.Set<T>();

        public async Task<ResultT<T>> AddAsync(T entity, CancellationToken cancellation = default)
        {
            if (entity == null)
            {
                return Errors.NullValue;
            }
            await _DbSet.AddAsync(entity, cancellation);
            return entity;
        }

        public async Task<Result> AddRangeAsync(ICollection<T> entities, CancellationToken cancellation = default)
        {
            if (entities is null || entities.Count == 0)
            {
                return Errors.NullValue;
            }
            await _DbSet.AddRangeAsync(entities, cancellation);
            return Result.Success();

        }

        public ResultT<IDbContextTransaction> BeginTransaction()
        {
            var beginTransaction= _context.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
            return ResultT<IDbContextTransaction>.Success(beginTransaction);
        }

        public async Task<ResultT<IDbContextTransaction>> BeginTransactionAsync(CancellationToken cancellation = default)
        {
            var beginTransAsync = await _context.Database.BeginTransactionAsync(System.Data.IsolationLevel.ReadCommitted,cancellation);
            return ResultT<IDbContextTransaction>.Success(beginTransAsync);
        }

        public Result Commit()
        {
            if( _context.Database.CurrentTransaction is IDbContextTransaction transaction )
            {
                transaction.Commit();
            }
            return Result.Success();
        }

        public async Task<Result> CommitAsync(CancellationToken cancellation = default)
        {
            if (_context.Database.CurrentTransaction is IDbContextTransaction transaction)
            {
                await transaction.CommitAsync(cancellation);
            }
            return Result.Success();
        }

        public Result Delete(T entity)
        {
            if (entity is null)
                return Errors.NullValue;
            _DbSet.Remove(entity);
            return Result.Success();
        }

        public Result DeleteRange(ICollection<T> entities)
        {
            if (entities is null || entities.Count == 0)
                return Errors.NullValue;
            _DbSet.RemoveRange(entities);
            return Result.Success();
        }

        public Result RollBack()
        {
            if (_context.Database.CurrentTransaction is IDbContextTransaction transaction)
            {
                transaction.Rollback();
            }
            return Result.Success();
        }

        public async Task<Result> RollBackAsync(CancellationToken cancellation = default)
        {
            if (_context.Database.CurrentTransaction is IDbContextTransaction transaction)
            {
                await transaction.RollbackAsync(cancellation);
            }
            return Result.Success();
        }

        public async Task<Result> SaveChangesAsync(CancellationToken cancellation = default)
        {
            try
            {
                int changes = await _context.SaveChangesAsync(cancellation);
                return Result.Success();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return new Error("Repository.Concurrency", "A concurrency conflict occurred. The data may have been modified by another user.");
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is not null)
                {
                    if (ex.InnerException.Message.Contains("unique constraint") || ex.InnerException.Message.Contains("UNIQUE KEY"))
                    {
                        return new Error("Repository.UniqueConstraint", "A value for a unique field already exists.");
                    }
                }
                return new Error("Repository.DatabaseUpdate", $"A database error occurred: {ex.InnerException?.Message ?? ex.Message}");
            }
            catch (Exception ex)
            {
                return new Error("Repository.SaveChanges", $"An unexpected error occurred: {ex.Message}");
            }
        }

        public Result Update(T entity)
        {
            if (entity is null)
                return Errors.NullValue;

            _DbSet.Update(entity);
            return Result.Success();
        }

        public Result UpdateRange(ICollection<T> entities)
        {
            if (entities is null || entities.Count == 0)
                return Errors.NullValue;

            _DbSet.UpdateRange(entities);
            return Result.Success();
        }
        public async Task<Result> BulkInsertAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            await _context.BulkInsertAsync(entities, options =>
            {
                options.BatchSize = 1000;
            },cancellationToken: cancellationToken);
            return Result.Success();
        }
    }
}
