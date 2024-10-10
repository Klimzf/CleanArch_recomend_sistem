using Microsoft.EntityFrameworkCore;
using CleanArch_recomend_sistem.Core;
using System.Security.Principal;


namespace CleanArch_recomend_sistem.Infrastructure.Db;

public class BasicRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity, new()
{
    private static readonly ProjectContext _context = new();

    public Task AddRange(IEnumerable<TEntity> entities, CancellationToken cancellationToken) =>
         Task.Run(async () =>
         {
             _context.AddRange(entities);
             try
             {
                 await _context.SaveChangesAsync(cancellationToken);
             }
             catch (DbUpdateException ex)
             {
                 // Получите подробное сообщение
                 var innerException = ex.InnerException?.Message;
                 Console.WriteLine($"Ошибка при обновлении базы данных: {innerException}");
             }
         }, cancellationToken);
    public Task Add(TEntity entity, CancellationToken cancellationToken)=>
        Task.Run(async () =>
        {
            _context.AddRange(entity);
            try
            {
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateException ex)
            {
                // Получите подробное сообщение
                var innerException = ex.InnerException?.Message;
                Console.WriteLine($"Ошибка при обновлении базы данных: {innerException}");
            }
        }, cancellationToken);
    public Task<IEnumerable<TEntity>> Get(CancellationToken cancellationToken) =>
        Task.FromResult(_context.Set<TEntity>().ToArray().AsEnumerable());

    public Task<IEnumerable<TEntity>> Get(Func<TEntity, bool> predicate, CancellationToken cancellationToken) =>
        Task.FromResult(_context.Set<TEntity>().Where(predicate).ToArray().AsEnumerable());

    public Task<IEnumerable<TEntity>> GetWithoutTracking(CancellationToken cancellationToken) =>
        Task.FromResult(_context.Set<TEntity>().AsNoTracking().ToArray().AsEnumerable());

    public Task<IEnumerable<TEntity>> GetWithoutTracking(Func<TEntity, bool> predicate, CancellationToken cancellationToken) =>
        Task.FromResult(_context.Set<TEntity>().AsNoTracking().Where(predicate).ToArray().AsEnumerable());

    public Task RemoveRange(IEnumerable<TEntity> entities, CancellationToken cancellationToken) =>
        Task.Run(async () =>
        {
            _context.RemoveRange(entities);
            await _context.SaveChangesAsync(cancellationToken);
        }, cancellationToken);

    public Task UpdateRange(IEnumerable<TEntity> entities, CancellationToken cancellationToken) =>
        Task.Run(async () =>
        {
            _context.UpdateRange(entities);
            await _context.SaveChangesAsync(cancellationToken);
        }, cancellationToken);
}
