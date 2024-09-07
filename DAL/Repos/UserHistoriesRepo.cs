using System.Linq.Expressions;
using System.Runtime.InteropServices;
using Common.Attributes;
using DAL.Attributes;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace DAL.Repos;

public interface IUserHistoriesRepo
{
    void SetRedisKey(string key);
    (UserHistoriesDbModel? entity, bool success) Create(UserHistoriesDbModel? model);

    /// <inheritdoc/>
    (UserHistoriesDbModel? entity, bool sucess) ReadById(int id);

    /// <inheritdoc/>
    (List<UserHistoriesDbModel>? entities, bool success) Where(Expression<Func<UserHistoriesDbModel, bool>> statement,
        [Optional] string includes);

    /// <inheritdoc/>
    (UserHistoriesDbModel? entity, bool success) WhereSingle(Expression<Func<UserHistoriesDbModel, bool>> statement);

    /// <inheritdoc/>
    bool Contains(Expression<Func<UserHistoriesDbModel, bool>> statement);

    /// <inheritdoc/>
    (UserHistoriesDbModel entity, bool success) Update(UserHistoriesDbModel model);

    /// <inheritdoc/>
    bool Delete(UserHistoriesDbModel model);
}

[SingletonRegistration]
[Repository]
public class UserHistoriesRepo : RepoBase<UserHistoriesDbModel>, IUserHistoriesRepo
{
    public UserHistoriesRepo(ILogger<RepoBase<UserHistoriesDbModel>> logger, IDbContextFactory<HadurContext> context, IConnectionMultiplexer redis) : base(logger, context, redis)
    {
    }
}