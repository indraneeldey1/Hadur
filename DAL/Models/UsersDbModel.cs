using System.ComponentModel.DataAnnotations.Schema;
using DAL.Models;

namespace Hadur.DAL.Database;

[Table("Users")]
public class UsersDbModel : DbBase
{
  public string Username { get; set; } = "";
  public string Password { get; set; } = "";
  public string Email { get; set; } = "";

  // Collection of user history
  public List<UserHistoriesDbModel> History { get; set; } = new();
}