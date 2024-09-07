using System.Linq.Expressions;
using System.Runtime.InteropServices;
using Common.Attributes;
using DAL.Attributes;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace DAL.Repos;

public interface IConfigurationRepo
{
    void SetRedisKey(string key);
    (ConfigurationDbModel? entity, bool success) Create(ConfigurationDbModel? model);

    /// <inheritdoc/>
    (ConfigurationDbModel? entity, bool sucess) ReadById(int id);

    /// <inheritdoc/>
    (List<ConfigurationDbModel>? entities, bool success) Where(Expression<Func<ConfigurationDbModel, bool>> statement,
        [Optional] string includes);

    /// <inheritdoc/>
    (ConfigurationDbModel? entity, bool success) WhereSingle(Expression<Func<ConfigurationDbModel, bool>> statement);

    /// <inheritdoc/>
    bool Contains(Expression<Func<ConfigurationDbModel, bool>> statement);

    /// <inheritdoc/>
    (ConfigurationDbModel entity, bool success) Update(ConfigurationDbModel model);

    /// <inheritdoc/>
    bool Delete(ConfigurationDbModel model);
}

[SingletonRegistration]
[Repository]
public class ConfigurationRepo : RepoBase<ConfigurationDbModel>, IConfigurationRepo
{
    public ConfigurationRepo(ILogger<RepoBase<ConfigurationDbModel>> logger, IDbContextFactory<HadurContext> context, IConnectionMultiplexer redis) : base(logger, context, redis)
    {
        SetRedisKey("configurations");
    }
}