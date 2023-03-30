using System.ComponentModel.DataAnnotations.Schema;
using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace Hadur.DAL.Database;

[Table("CloudTags")]
public class CloudTagsDbModel : DbBase
{
  public string Name { get; set; } = "";
}

public class CloudTagRepo : RepoBase<CloudTagsDbModel>
{
 
  public CloudTagRepo(ILogger<RepoBase<CloudTagsDbModel>> logger, IDbContextFactory<HadurContext> context, IConnectionMultiplexer redis) : base(logger, context, redis)
  {
   
    SetRedisKey("cloudtags");
  }

  public IEnumerable<CloudTagsDbModel> AutoCompleteTags(string tag) =>
    //TODO: add in search auto complete against caching
    new List<CloudTagsDbModel>();
  
}