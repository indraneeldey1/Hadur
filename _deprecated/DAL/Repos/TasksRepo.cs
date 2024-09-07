using System.Linq.Expressions;
using System.Runtime.InteropServices;
using Common.Attributes;
using DAL.Attributes;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace DAL.Repos;

public interface ITasksRepo
{
    void SetRedisKey(string key);
    (TasksDbModel? entity, bool success) Create(TasksDbModel? model);

    /// <inheritdoc/>
    (TasksDbModel? entity, bool sucess) ReadById(int id);

    /// <inheritdoc/>
    (List<TasksDbModel>? entities, bool success) Where(Expression<Func<TasksDbModel, bool>> statement,
        [Optional] string includes);

    /// <inheritdoc/>
    (TasksDbModel? entity, bool success) WhereSingle(Expression<Func<TasksDbModel, bool>> statement);

    /// <inheritdoc/>
    bool Contains(Expression<Func<TasksDbModel, bool>> statement);

    /// <inheritdoc/>
    (TasksDbModel entity, bool success) Update(TasksDbModel model);

    /// <inheritdoc/>
    bool Delete(TasksDbModel model);
}

[SingletonRegistration]
[Repository]
public class TasksRepo : RepoBase<TasksDbModel>, ITasksRepo
{
    public TasksRepo(ILogger<RepoBase<TasksDbModel>> logger, IDbContextFactory<HadurContext> context, IConnectionMultiplexer redis) : base(logger, context, redis)
    {
    }
}