using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models;
[Table("Permissions")]
public class PermissionsDbModel : DbBase
{

  public string Name { get; set; }= "";
  public string PermissionsSet { get; set; }= "";
}