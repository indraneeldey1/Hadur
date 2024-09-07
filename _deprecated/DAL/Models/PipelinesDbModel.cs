using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models;
[Table("Pipelines")]
public class PipelinesDbModel: DbBase
{
  public string Name { get; set; }= "";
  
  public int[] CloudTags { get; set; } = new int[]{};
}