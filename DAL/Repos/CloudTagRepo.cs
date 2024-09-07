using System.Linq.Expressions;
using System.Runtime.InteropServices;
using Common.Attributes;
using DAL.Attributes;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace DAL.Repos;

public interface ICloudTagRepo
{
    IEnumerable<CloudTagsDbModel> AutoCompleteTags(string tag);
    void SetRedisKey(string key);
    (CloudTagsDbModel? entity, bool success) Create(CloudTagsDbModel? model);

    /// <inheritdoc/>
    (CloudTagsDbModel? entity, bool sucess) ReadById(int id);

    /// <inheritdoc/>
    (List<CloudTagsDbModel>? entities, bool success) Where(Expression<Func<CloudTagsDbModel, bool>> statement,
        [Optional] string includes);

    /// <inheritdoc/>
    (CloudTagsDbModel? entity, bool success) WhereSingle(Expression<Func<CloudTagsDbModel, bool>> statement);

    /// <inheritdoc/>
    bool Contains(Expression<Func<CloudTagsDbModel, bool>> statement);

    /// <inheritdoc/>
    (CloudTagsDbModel entity, bool success) Update(CloudTagsDbModel model);

    /// <inheritdoc/>
    bool Delete(CloudTagsDbModel model);
}

[SingletonRegistration]
[Repository]
public class CloudTagRepo : RepoBase<CloudTagsDbModel>, ICloudTagRepo
{
 
    public CloudTagRepo(ILogger<CloudTagRepo> logger, IDbContextFactory<HadurContext> context, IConnectionMultiplexer redis) : base(logger, context, redis)
    {
   
        SetRedisKey("cloudtags");
    }

    public IEnumerable<CloudTagsDbModel> AutoCompleteTags(string tag) =>
        //TODO: add in search auto complete against caching
        new List<CloudTagsDbModel>();
  
}