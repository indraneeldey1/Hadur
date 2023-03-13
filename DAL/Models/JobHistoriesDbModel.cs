using System.ComponentModel.DataAnnotations.Schema;
using DAL.Models;

namespace Hadur.DAL.Database;

[Table("JobHistories")]
public class JobHistoriesDbModel: DbBase
{
  
  public int JobId { get; set; }
  public JobsDbModel Job { get; set; } = new();
  public string Status { get; set; } = "";
  public DateTime CompleteDate { get; set; }
}