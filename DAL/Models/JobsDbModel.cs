using System.ComponentModel.DataAnnotations.Schema;
using DAL.Models;

namespace Hadur.DAL.Database;

[Table("Jobs")]
public class JobsDbModel : DbBase
{
  public string Name { get; set; } = "";
  public DateTime RanLast { get; set; }
  public bool Status { get; set; }
  
  public int[] CloudTagIds { get; set; } = new int[] { };
  
  public ICollection<CloudTagsDbModel> CloudTags { get; set; }

  public int[] PipelineIds { get; set; } = new int[] { };
  
  public ICollection<PipelinesDbModel> Pipelines { get; set; }
  
  public int[] ConfigurationIds { get; set; }
  
  public ICollection<ConfigurationDbModel> Configurations { get; set; }
}