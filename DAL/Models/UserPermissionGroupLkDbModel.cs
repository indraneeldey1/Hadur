using System.ComponentModel.DataAnnotations.Schema;
using DAL.Models;

namespace Hadur.DAL.Database;

[Table("User_PermissionGroup_LK")]
public class UserPermissionGroupLkDbModel : DbBase
{
  [ForeignKey("User")]
  public int UserId { get; set; }

  public UsersDbModel User { get; set; } = new();

  [ForeignKey("PermissionGroup")]
  public int PermissionGroupId { get; set; }

  public PermissionGroupsDbModel PermissionGroup { get; set; } = new();
}