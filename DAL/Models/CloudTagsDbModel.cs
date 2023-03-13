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
  private readonly ILogger<RepoBase<CloudTagsDbModel>> _logger;

  public CloudTagRepo(ILogger<RepoBase<CloudTagsDbModel>> logger, IDbContextFactory<HadurContext> context, IConnectionMultiplexer redis) : base(logger, context, redis)
  {
    _logger = logger;
  }
}