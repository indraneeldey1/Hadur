using System.ComponentModel.DataAnnotations.Schema;
using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace Hadur.DAL.Database;
[Table("PermissionsGroup")]
public class PermissionGroupsDbModel : DbBase
{
  public string Name { get; set; }= "";
  
  public int[] PermissionsId { get; set; } = new int[] { };
  public ICollection<PermissionsDbModel> Permissions { get; set; } 
}

public class PermissionsGroupsRepo : RepoBase<PermissionGroupsDbModel>
{
  public PermissionsGroupsRepo(ILogger<RepoBase<PermissionGroupsDbModel>> logger, IDbContextFactory<HadurContext> context, IConnectionMultiplexer redis) : base(logger, context, redis)
  {
    SetRedisKey("permissions:groups");
  }
}