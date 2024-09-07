using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models;
[Table("Projects")]
public  class ProjectsDbModel: DbBase
{
  public string Name { get; set; } = "";
  
  
  public int[] CloudTagIds { get; set; } = new int[]{};
  public ICollection<CloudTagsDbModel> CloudTags { get; set; }

  public int[] JobsIds { get; set; } = new int[] { };
  public ICollection<JobsDbModel> Jobs { get; set; }
}