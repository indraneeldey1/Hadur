using System.ComponentModel.DataAnnotations.Schema;
using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace Hadur.DAL.Database;

[Table("Users")]
public class UsersDbModel : DbBase
{
  public string Username { get; set; } = "";
  public string Password { get; set; } = "";
  public string Email { get; set; } = "";

  // Collection of user history
  public List<UserHistoriesDbModel> History { get; set; } = new();
  
  public int[] PermissionsGroupsIds { get; set; } = new int[] { };
  public ICollection<PermissionsDbModel> PermissionsGroups { get; set; }
}

public class UsersRepo : RepoBase<UsersDbModel>
{
  public UsersRepo(ILogger<RepoBase<UsersDbModel>> logger, IDbContextFactory<HadurContext> context, IConnectionMultiplexer redis) : base(logger, context, redis)
  {
  }
}