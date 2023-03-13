using System.ComponentModel.DataAnnotations.Schema;
using DAL.Models;

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