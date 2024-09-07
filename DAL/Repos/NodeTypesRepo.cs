using System.Linq.Expressions;
using System.Runtime.InteropServices;
using Common.Attributes;
using DAL.Attributes;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace DAL.Repos;

public interface INodeTypesRepo
{
    void SetRedisKey(string key);
    (NodeTypesDbModel? entity, bool success) Create(NodeTypesDbModel? model);

    /// <inheritdoc/>
    (NodeTypesDbModel? entity, bool sucess) ReadById(int id);

    /// <inheritdoc/>
    (List<NodeTypesDbModel>? entities, bool success) Where(Expression<Func<NodeTypesDbModel, bool>> statement,
        [Optional] string includes);

    /// <inheritdoc/>
    (NodeTypesDbModel? entity, bool success) WhereSingle(Expression<Func<NodeTypesDbModel, bool>> statement);

    /// <inheritdoc/>
    bool Contains(Expression<Func<NodeTypesDbModel, bool>> statement);

    /// <inheritdoc/>
    (NodeTypesDbModel entity, bool success) Update(NodeTypesDbModel model);

    /// <inheritdoc/>
    bool Delete(NodeTypesDbModel model);
}

[SingletonRegistration]
[Repository]
public class NodeTypesRepo : RepoBase<NodeTypesDbModel>, INodeTypesRepo
{
    public NodeTypesRepo(ILogger<RepoBase<NodeTypesDbModel>> logger, IDbContextFactory<HadurContext> context, IConnectionMultiplexer redis) : base(logger, context, redis)
    {
        SetRedisKey("node:types");
    }
}