using System.Linq.Expressions;
using System.Runtime.InteropServices;
using Common.Attributes;
using DAL.Attributes;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace DAL.Repos;

public interface IPermissionsGroupsRepo
{
    void SetRedisKey(string key);
    (PermissionGroupsDbModel? entity, bool success) Create(PermissionGroupsDbModel? model);

    /// <inheritdoc/>
    (PermissionGroupsDbModel? entity, bool sucess) ReadById(int id);

    /// <inheritdoc/>
    (List<PermissionGroupsDbModel>? entities, bool success) Where(Expression<Func<PermissionGroupsDbModel, bool>> statement,
        [Optional] string includes);

    /// <inheritdoc/>
    (PermissionGroupsDbModel? entity, bool success) WhereSingle(Expression<Func<PermissionGroupsDbModel, bool>> statement);

    /// <inheritdoc/>
    bool Contains(Expression<Func<PermissionGroupsDbModel, bool>> statement);

    /// <inheritdoc/>
    (PermissionGroupsDbModel entity, bool success) Update(PermissionGroupsDbModel model);

    /// <inheritdoc/>
    bool Delete(PermissionGroupsDbModel model);
}

[SingletonRegistration]
[Repository]
public class PermissionsGroupsRepo : RepoBase<PermissionGroupsDbModel>, IPermissionsGroupsRepo
{
    public PermissionsGroupsRepo(ILogger<RepoBase<PermissionGroupsDbModel>> logger, IDbContextFactory<HadurContext> context, IConnectionMultiplexer redis) : base(logger, context, redis)
    {
        SetRedisKey("permissions:groups");
    }
}