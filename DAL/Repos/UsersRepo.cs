using System.Linq.Expressions;
using System.Runtime.InteropServices;
using Common.Attributes;
using DAL.Attributes;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace DAL.Repos;

public interface IUsersRepo
{
    void SetRedisKey(string key);
    (UsersDbModel? entity, bool success) Create(UsersDbModel? model);

    /// <inheritdoc/>
    (UsersDbModel? entity, bool sucess) ReadById(int id);

    /// <inheritdoc/>
    (List<UsersDbModel>? entities, bool success) Where(Expression<Func<UsersDbModel, bool>> statement,
        [Optional] string includes);

    /// <inheritdoc/>
    (UsersDbModel? entity, bool success) WhereSingle(Expression<Func<UsersDbModel, bool>> statement);

    /// <inheritdoc/>
    bool Contains(Expression<Func<UsersDbModel, bool>> statement);

    /// <inheritdoc/>
    (UsersDbModel entity, bool success) Update(UsersDbModel model);

    /// <inheritdoc/>
    bool Delete(UsersDbModel model);
}

[SingletonRegistration]
[Repository]
public class UsersRepo : RepoBase<UsersDbModel>, IUsersRepo
{
    public UsersRepo(ILogger<RepoBase<UsersDbModel>> logger, IDbContextFactory<HadurContext> context, IConnectionMultiplexer redis) : base(logger, context, redis)
    {
    }
}