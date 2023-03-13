﻿using System.ComponentModel.DataAnnotations.Schema;
using DAL.Models;

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