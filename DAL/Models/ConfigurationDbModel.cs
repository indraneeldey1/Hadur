using System.ComponentModel.DataAnnotations.Schema;
using DAL.Models;

namespace Hadur.DAL.Database;

[Table("Configuration")]
public class ConfigurationDbModel: DbBase
{
  public string Type { get; set; } = "";
  public string Table { get; set; }= "";
  public int TableId { get; set; }
  public string Values { get; set; }= "";
}