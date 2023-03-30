using System.ComponentModel.DataAnnotations.Schema;
using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace Hadur.DAL.Database;

[Table("Configuration")]
public class ConfigurationDbModel: DbBase
{
  public string Type { get; set; } = "";
  public string Table { get; set; }= "";
  public int TableId { get; set; }
  public string Values { get; set; }= "";
}

public class ConfigurationRepo : RepoBase<ConfigurationDbModel>
{
  public ConfigurationRepo(ILogger<RepoBase<ConfigurationDbModel>> logger, IDbContextFactory<HadurContext> context, IConnectionMultiplexer redis) : base(logger, context, redis)
  {
    SetRedisKey("configurations");
  }
}