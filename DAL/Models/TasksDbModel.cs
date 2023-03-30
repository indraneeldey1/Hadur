using System.ComponentModel.DataAnnotations.Schema;
using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace Hadur.DAL.Database;

[Table("Tasks")]
public class TasksDbModel : DbBase
{
  [ForeignKey("Job")]
  public int JobId { get; set; }

  public JobsDbModel Job { get; set; } = new();

  [ForeignKey("Node")]
  public int NodeTypeId { get; set; }

  public NodeTypesDbModel Node { get; set; } = new();

  public ICollection<TaskHistoriesDbModel> TaskHistory { get; set; }
}

public class TasksRepo : RepoBase<TasksDbModel>
{
  public TasksRepo(ILogger<RepoBase<TasksDbModel>> logger, IDbContextFactory<HadurContext> context, IConnectionMultiplexer redis) : base(logger, context, redis)
  {
  }
}