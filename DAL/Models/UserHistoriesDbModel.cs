﻿using System.ComponentModel.DataAnnotations.Schema;
using DAL.Models;

namespace Hadur.DAL.Database;
[Table("UserHistories")]
public class UserHistoriesDbModel: DbBase
{

  public string Table { get; set; } = "";
  public string PreviousValue { get; set; }= "";
  public string NewValue { get; set; }= "";
  
  public int UserId { get; set; }
  public UsersDbModel User { get; set; } = new();
}