using System.Linq.Expressions;
using System.Runtime.InteropServices;
using Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace DAL.Models;

public interface IRepoBase<T>
{
}

public abstract class RepoBase<TEntity> : IRepoBase<TEntity> where TEntity : DbBase
{
    private readonly HadurContext Context;
    protected ILogger<RepoBase<TEntity>> _logger;
    private protected IDatabase CacheDb;

    private string RedisKey { get; set; } = String.Empty;

    private DbSet<TEntity> Set { get; }

    protected RepoBase(ILogger<RepoBase<TEntity>> logger, IDbContextFactory<HadurContext> context,
        IConnectionMultiplexer redis)
    {
        Context = context.CreateDbContext();
        Set = Context.Set<TEntity>();
        _logger = logger;
        CacheDb = redis.GetDatabase();
    }

    public void SetRedisKey(string key) => RedisKey = key;
    
    public virtual (TEntity? entity, bool success) Create(TEntity? model)
    {
        try
        {
            if (model == null) return (entity: null, success: false);

            model.Created = DateTime.Now;

            Set.Add(model);
            Context.SaveChanges();
            return (entity: model, success: true);
        }
        catch (Exception e)
        {
            _logger.LogCritical(e.Message);
            return (entity: null, success: false);
        }
    }

    /// <inheritdoc/>
    public virtual (TEntity? entity, bool sucess) ReadById(int id)
    {
        try
        {
            if (!CacheDb.KeyExists($"{RedisKey}:{id}"))
                return id <= 0 ? (entity: null, sucess: false) : (entity: Set.First(o => o.Id == id), sucess: true);
            
            TEntity model = CacheDb.HashGetAll($"{RedisKey}:{id}").ToObject<TEntity>();
            return (entity: model, sucess: true);
        }
        catch (Exception e)
        {
            _logger.LogCritical(e.Message);
            return (entity: null, sucess: false);
        }
    }

#region Searches

    /// <inheritdoc/>
    public virtual (List<TEntity>? entities, bool success) Where(Expression<Func<TEntity, bool>> statement,
        [Optional] string includes)
    {
        try
        {
            
            List<TEntity>? foundValues = null;

            foundValues = string.IsNullOrEmpty(includes)
                ? Set.Where(statement).ToList()
                : Set.Where(statement).Include(includes).ToList();

            return (entities: foundValues, success: true);
        }
        catch (Exception e)
        {
            _logger.LogCritical(e.Message);
        }

        return (entities: null, success: false);
    }

    /// <inheritdoc/>
    public virtual (TEntity? entity, bool success) WhereSingle(Expression<Func<TEntity, bool>> statement)
    {
        try
        {
            return (entity: Set.First(statement), success: true);
        }
        catch (Exception e)
        {
            _logger.LogCritical(e.Message);
        }

        return (entity: null, success: false);
    }

    /// <inheritdoc/>
    public virtual bool Contains(Expression<Func<TEntity, bool>> statement)
    {
        try
        {
            return Set.Any(statement);
        }
        catch (Exception e)
        {
            _logger.LogCritical(e.Message);
            throw;
        }
    }

#endregion


    /// <inheritdoc/>
    public virtual (TEntity entity, bool success) Update(TEntity model)
    {
        try
        {
            if (model == null) throw new ArgumentException();

            model.UpdatedLast = DateTime.Now;

            TEntity result = Set.First(o => o.Id == model.Id);
            result = model;
            Context.SaveChanges();
            return (entity: result, success: true);
        }
        catch (Exception e)
        {
            _logger.LogCritical(e.Message);
        }

        return (entity: null, success: false)!;
    }

    /// <inheritdoc/>
    public virtual bool Delete(TEntity model)
    {
        try
        {
            if (model == null) throw new ArgumentException();
            Set.Remove(model);
            Context.SaveChanges();

            return true;
        }
        catch (Exception e)
        {
            _logger.LogCritical(e.Message);
        }

        return false;
    }
}