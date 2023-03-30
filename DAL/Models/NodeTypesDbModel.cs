using System.ComponentModel.DataAnnotations.Schema;
using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace Hadur.DAL.Database;

[Table("NodeTypes")]
public class NodeTypesDbModel : DbBase
{
  public string Name { get; set; } = "";

  [ForeignKey("Configuration")]
  public int ConfigurationId { get; set; }

  public string Version { get; set; } = "";

  public string Folder { get; set; } = "";

  public string Variables { get; set; } = "";

  public int[] CloudTagsIds { get; set; } = new int[]{};
  
  public ICollection<CloudTagsDbModel> CloudTags { get; set; }

  public int[] ConfigurationIds { get; set; } = new int[]{};
  
  public ICollection<ConfigurationDbModel> Configurations { get; set; }
}

public class NodeTypesRepo : RepoBase<NodeTypesDbModel>
{
  public NodeTypesRepo(ILogger<RepoBase<NodeTypesDbModel>> logger, IDbContextFactory<HadurContext> context, IConnectionMultiplexer redis) : base(logger, context, redis)
  {
    SetRedisKey("node:types");
  }
}