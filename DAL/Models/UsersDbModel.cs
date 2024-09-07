using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models;

[Table("Users")]
public class UsersDbModel : DbBase
{
  public string Username { get; set; } = "";
  public string Password { get; set; } = "";
  public string Email { get; set; } = "";

  // Collection of user history
  public List<UserHistoriesDbModel> History { get; set; } = new();
  
  public int[] PermissionsGroupsIds { get; set; } = new int[] { };
  public ICollection<PermissionsDbModel> PermissionsGroups { get; set; }
}