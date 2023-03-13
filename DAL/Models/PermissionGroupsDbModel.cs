using System.ComponentModel.DataAnnotations.Schema;
using DAL.Models;

namespace Hadur.DAL.Database;
[Table("PermissionsGroup")]
public class PermissionGroupsDbModel : DbBase
{
  public string Name { get; set; }= "";
  
  public int[] PermissionsId { get; set; } = new int[] { };
  public ICollection<PermissionsDbModel> Permissions { get; set; } 
}