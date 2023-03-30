using System.ComponentModel.DataAnnotations.Schema;
using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace Hadur.DAL.Database;

[Table("TaskHistories")]
public class TaskHistoriesDbModel : DbBase
{
  [ForeignKey("Task")]
  public int TaskId { get; set; }

  public TasksDbModel Task { get; set; } = new();

  [ForeignKey("RanBy")]
  public int RanById { get; set; }

  public UsersDbModel RanBy { get; set; } = new();

  public DateTime RunTime { get; set; }
  public string RunDuration { get; set; } = "";
  public string Data { get; set; } = "";

  public int JobHistoryId { get; set; }
}

public class TaskHistoriesRepo : RepoBase<TaskHistoriesDbModel>
{
  public TaskHistoriesRepo(ILogger<RepoBase<TaskHistoriesDbModel>> logger, IDbContextFactory<HadurContext> context, IConnectionMultiplexer redis) : base(logger, context, redis)
  {
  }
}