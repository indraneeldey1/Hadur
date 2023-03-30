using System.ComponentModel.DataAnnotations.Schema;
using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace Hadur.DAL.Database;
[Table("Projects")]
public  class ProjectsDbModel: DbBase
{
  public string Name { get; set; } = "";
  
  
  public int[] CloudTagIds { get; set; } = new int[]{};
  public ICollection<CloudTagsDbModel> CloudTags { get; set; }

  public int[] JobsIds { get; set; } = new int[] { };
  public ICollection<JobsDbModel> Jobs { get; set; }
}

public class ProjectsRepo : RepoBase<ProjectsDbModel>
{
  public ProjectsRepo(ILogger<RepoBase<ProjectsDbModel>> logger, IDbContextFactory<HadurContext> context, IConnectionMultiplexer redis) : base(logger, context, redis)
  {
  }
}