using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models;
[Table("PermissionsGroup")]
public class PermissionGroupsDbModel : DbBase
{
  public string Name { get; set; }= "";
  
  public int[] PermissionsId { get; set; } = new int[] { };
  public ICollection<PermissionsDbModel> Permissions { get; set; } 
}