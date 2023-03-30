using System.ComponentModel.DataAnnotations.Schema;
using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace Hadur.DAL.Database;
[Table("UserHistories")]
public class UserHistoriesDbModel: DbBase
{

  public string Table { get; set; } = "";
  public string PreviousValue { get; set; }= "";
  public string NewValue { get; set; }= "";
  
  public int UserId { get; set; }
  public UsersDbModel User { get; set; } = new();
}

public class UserHistoriesRepo : RepoBase<UserHistoriesDbModel>
{
  public UserHistoriesRepo(ILogger<RepoBase<UserHistoriesDbModel>> logger, IDbContextFactory<HadurContext> context, IConnectionMultiplexer redis) : base(logger, context, redis)
  {
  }
}