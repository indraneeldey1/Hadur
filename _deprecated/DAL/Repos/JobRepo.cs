using System.Linq.Expressions;
using System.Runtime.InteropServices;
using Common.Attributes;
using DAL.Attributes;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace DAL.Repos;

public interface IJobRepo
{
    void SetRedisKey(string key);
    (JobsDbModel? entity, bool success) Create(JobsDbModel? model);

    /// <inheritdoc/>
    (JobsDbModel? entity, bool sucess) ReadById(int id);

    /// <inheritdoc/>
    (List<JobsDbModel>? entities, bool success) Where(Expression<Func<JobsDbModel, bool>> statement,
        [Optional] string includes);

    /// <inheritdoc/>
    (JobsDbModel? entity, bool success) WhereSingle(Expression<Func<JobsDbModel, bool>> statement);

    /// <inheritdoc/>
    bool Contains(Expression<Func<JobsDbModel, bool>> statement);

    /// <inheritdoc/>
    (JobsDbModel entity, bool success) Update(JobsDbModel model);

    /// <inheritdoc/>
    bool Delete(JobsDbModel model);
}

[SingletonRegistration]
[Repository]
public class JobRepo : RepoBase<JobsDbModel>, IJobRepo
{
    public JobRepo(ILogger<RepoBase<JobsDbModel>> logger, IDbContextFactory<HadurContext> context, IConnectionMultiplexer redis) : base(logger, context, redis)
    {
        SetRedisKey("jobs");
    }
}