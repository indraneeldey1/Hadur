using System.Linq.Expressions;
using System.Runtime.InteropServices;
using Common.Attributes;
using DAL.Attributes;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace DAL.Repos;

public interface IPermissionsRepo
{
    void SetRedisKey(string key);
    (PermissionsDbModel? entity, bool success) Create(PermissionsDbModel? model);

    /// <inheritdoc/>
    (PermissionsDbModel? entity, bool sucess) ReadById(int id);

    /// <inheritdoc/>
    (List<PermissionsDbModel>? entities, bool success) Where(Expression<Func<PermissionsDbModel, bool>> statement,
        [Optional] string includes);

    /// <inheritdoc/>
    (PermissionsDbModel? entity, bool success) WhereSingle(Expression<Func<PermissionsDbModel, bool>> statement);

    /// <inheritdoc/>
    bool Contains(Expression<Func<PermissionsDbModel, bool>> statement);

    /// <inheritdoc/>
    (PermissionsDbModel entity, bool success) Update(PermissionsDbModel model);

    /// <inheritdoc/>
    bool Delete(PermissionsDbModel model);
}

[SingletonRegistration]
[Repository]
public class PermissionsRepo : RepoBase<PermissionsDbModel>, IPermissionsRepo
{
    public PermissionsRepo(ILogger<RepoBase<PermissionsDbModel>> logger, IDbContextFactory<HadurContext> context, IConnectionMultiplexer redis) : base(logger, context, redis)
    {
        SetRedisKey("permissions");
    }
}