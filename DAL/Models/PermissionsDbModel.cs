using System.ComponentModel.DataAnnotations.Schema;
using DAL.Models;

namespace Hadur.DAL.Database;
[Table("Permissions")]
public class PermissionsDbModel : DbBase
{

  public string Name { get; set; }= "";
  public string PermissionsSet { get; set; }= "";
}