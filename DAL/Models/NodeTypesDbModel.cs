using System.ComponentModel.DataAnnotations.Schema;
using DAL.Models;

namespace Hadur.DAL.Database;

[Table("NodeTypes")]
public class NodeTypesDbModel : DbBase
{
  public string Name { get; set; } = "";

  [ForeignKey("Configuration")]
  public int ConfigurationId { get; set; }

  public string Version { get; set; } = "";

  public string Folder { get; set; } = "";

  public string Variables { get; set; } = "";

  public int[] CloudTagsIds { get; set; } = new int[]{};
  
  public ICollection<CloudTagsDbModel> CloudTags { get; set; }

  public int[] ConfigurationIds { get; set; } = new int[]{};
  
  public ICollection<ConfigurationDbModel> Configurations { get; set; }
}