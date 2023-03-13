using System.ComponentModel.DataAnnotations.Schema;
using DAL.Models;

namespace Hadur.DAL.Database;
[Table("Pipelines")]
public class PipelinesDbModel: DbBase
{
  public string Name { get; set; }= "";
  
  public int[] CloudTags { get; set; } = new int[]{};
}