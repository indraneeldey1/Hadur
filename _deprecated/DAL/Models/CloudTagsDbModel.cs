using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models;

[Table("CloudTags")]
public class CloudTagsDbModel : DbBase
{
  public string Name { get; set; } = "";
}