using System.Linq.Expressions;
using System.Runtime.InteropServices;
using Common.Attributes;
using DAL.Attributes;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace DAL.Repos;

public interface IProjectsRepo
{
    void SetRedisKey(string key);
    (ProjectsDbModel? entity, bool success) Create(ProjectsDbModel? model);

    /// <inheritdoc/>
    (ProjectsDbModel? entity, bool sucess) ReadById(int id);

    /// <inheritdoc/>
    (List<ProjectsDbModel>? entities, bool success) Where(Expression<Func<ProjectsDbModel, bool>> statement,
        [Optional] string includes);

    /// <inheritdoc/>
    (ProjectsDbModel? entity, bool success) WhereSingle(Expression<Func<ProjectsDbModel, bool>> statement);

    /// <inheritdoc/>
    bool Contains(Expression<Func<ProjectsDbModel, bool>> statement);

    /// <inheritdoc/>
    (ProjectsDbModel entity, bool success) Update(ProjectsDbModel model);

    /// <inheritdoc/>
    bool Delete(ProjectsDbModel model);
}

[SingletonRegistration]
[Repository]
public class ProjectsRepo : RepoBase<ProjectsDbModel>, IProjectsRepo
{
    public ProjectsRepo(ILogger<RepoBase<ProjectsDbModel>> logger, IDbContextFactory<HadurContext> context, IConnectionMultiplexer redis) : base(logger, context, redis)
    {
    }
}