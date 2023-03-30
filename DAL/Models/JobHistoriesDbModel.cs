using System.ComponentModel.DataAnnotations.Schema;
using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace Hadur.DAL.Database;

[Table("JobHistories")]
public class JobHistoriesDbModel: DbBase
{
  
  public int JobId { get; set; }
  public JobsDbModel Job { get; set; } = new();
  public string Status { get; set; } = "";
  public DateTime CompleteDate { get; set; }
}

public class JobHistoriesRepo : RepoBase<JobHistoriesDbModel>
{
  public JobHistoriesRepo(ILogger<RepoBase<JobHistoriesDbModel>> logger, IDbContextFactory<HadurContext> context, IConnectionMultiplexer redis) : base(logger, context, redis)
  {
    SetRedisKey("jobs:histories");
  }
}