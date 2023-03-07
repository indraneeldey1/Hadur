using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models;

public abstract class DbBase
{
    [Key]
    public int Id { get; set; }
    
    public DateTime Created { get; set; } = DateTime.Now;
    
    [ForeignKey("CreatedBy")]
    public int CreatedById { get; set; }
    public UsersDb CreatedBy { get; set; }
    
    public DateTime? UpdatedLast { get; set; } = null;
    
    [ForeignKey("ModifiedBy")]
    public int UpdatedById { get; set; }
    public UsersDb UpdatedBy { get; set; }
}