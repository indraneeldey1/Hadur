using System.Linq.Expressions;
using System.Runtime.InteropServices;
using Common.Attributes;
using DAL.Attributes;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace DAL.Repos;

public interface IPipelinesRepo
{
    void SetRedisKey(string key);
    (PipelinesDbModel? entity, bool success) Create(PipelinesDbModel? model);

    /// <inheritdoc/>
    (PipelinesDbModel? entity, bool sucess) ReadById(int id);

    /// <inheritdoc/>
    (List<PipelinesDbModel>? entities, bool success) Where(Expression<Func<PipelinesDbModel, bool>> statement,
        [Optional] string includes);

    /// <inheritdoc/>
    (PipelinesDbModel? entity, bool success) WhereSingle(Expression<Func<PipelinesDbModel, bool>> statement);

    /// <inheritdoc/>
    bool Contains(Expression<Func<PipelinesDbModel, bool>> statement);

    /// <inheritdoc/>
    (PipelinesDbModel entity, bool success) Update(PipelinesDbModel model);

    /// <inheritdoc/>
    bool Delete(PipelinesDbModel model);
}

[SingletonRegistration]
[Repository]
public class PipelinesRepo : RepoBase<PipelinesDbModel>, IPipelinesRepo
{
    public PipelinesRepo(ILogger<RepoBase<PipelinesDbModel>> logger, IDbContextFactory<HadurContext> context, IConnectionMultiplexer redis) : base(logger, context, redis)
    {
    }
}