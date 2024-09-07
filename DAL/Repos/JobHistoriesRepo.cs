using System.Linq.Expressions;
using System.Runtime.InteropServices;
using Common.Attributes;
using DAL.Attributes;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace DAL.Repos;

public interface IJobHistoriesRepo
{
    void SetRedisKey(string key);
    (JobHistoriesDbModel? entity, bool success) Create(JobHistoriesDbModel? model);

    /// <inheritdoc/>
    (JobHistoriesDbModel? entity, bool sucess) ReadById(int id);

    /// <inheritdoc/>
    (List<JobHistoriesDbModel>? entities, bool success) Where(Expression<Func<JobHistoriesDbModel, bool>> statement,
        [Optional] string includes);

    /// <inheritdoc/>
    (JobHistoriesDbModel? entity, bool success) WhereSingle(Expression<Func<JobHistoriesDbModel, bool>> statement);

    /// <inheritdoc/>
    bool Contains(Expression<Func<JobHistoriesDbModel, bool>> statement);

    /// <inheritdoc/>
    (JobHistoriesDbModel entity, bool success) Update(JobHistoriesDbModel model);

    /// <inheritdoc/>
    bool Delete(JobHistoriesDbModel model);
}

[SingletonRegistration]
[Repository]
public class JobHistoriesRepo : RepoBase<JobHistoriesDbModel>, IJobHistoriesRepo
{
    public JobHistoriesRepo(ILogger<RepoBase<JobHistoriesDbModel>> logger, IDbContextFactory<HadurContext> context, IConnectionMultiplexer redis) : base(logger, context, redis)
    {
        SetRedisKey("jobs:histories");
    }
}