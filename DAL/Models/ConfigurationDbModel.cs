using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models;

[Table("Configuration")]
public class ConfigurationDbModel: DbBase
{
  public string Type { get; set; } = "";
  public string Table { get; set; }= "";
  public int TableId { get; set; }
  public string Values { get; set; }= "";
}