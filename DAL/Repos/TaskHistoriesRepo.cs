using System.Linq.Expressions;
using System.Runtime.InteropServices;
using Common.Attributes;
using DAL.Attributes;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace DAL.Repos;

public interface ITaskHistoriesRepo
{
    void SetRedisKey(string key);
    (TaskHistoriesDbModel? entity, bool success) Create(TaskHistoriesDbModel? model);

    /// <inheritdoc/>
    (TaskHistoriesDbModel? entity, bool sucess) ReadById(int id);

    /// <inheritdoc/>
    (List<TaskHistoriesDbModel>? entities, bool success) Where(Expression<Func<TaskHistoriesDbModel, bool>> statement,
        [Optional] string includes);

    /// <inheritdoc/>
    (TaskHistoriesDbModel? entity, bool success) WhereSingle(Expression<Func<TaskHistoriesDbModel, bool>> statement);

    /// <inheritdoc/>
    bool Contains(Expression<Func<TaskHistoriesDbModel, bool>> statement);

    /// <inheritdoc/>
    (TaskHistoriesDbModel entity, bool success) Update(TaskHistoriesDbModel model);

    /// <inheritdoc/>
    bool Delete(TaskHistoriesDbModel model);
}

[SingletonRegistration]
[Repository]
public class TaskHistoriesRepo : RepoBase<TaskHistoriesDbModel>, ITaskHistoriesRepo
{
    public TaskHistoriesRepo(ILogger<RepoBase<TaskHistoriesDbModel>> logger, IDbContextFactory<HadurContext> context, IConnectionMultiplexer redis) : base(logger, context, redis)
    {
    }
}