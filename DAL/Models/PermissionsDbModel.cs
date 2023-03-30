using System.ComponentModel.DataAnnotations.Schema;
using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace Hadur.DAL.Database;
[Table("Permissions")]
public class PermissionsDbModel : DbBase
{

  public string Name { get; set; }= "";
  public string PermissionsSet { get; set; }= "";
}

public class PermissionsRepo : RepoBase<PermissionsDbModel>
{
  public PermissionsRepo(ILogger<RepoBase<PermissionsDbModel>> logger, IDbContextFactory<HadurContext> context, IConnectionMultiplexer redis) : base(logger, context, redis)
  {
    SetRedisKey("permissions");
  }
}