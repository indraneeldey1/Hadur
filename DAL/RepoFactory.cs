using Common.Attributes;
using Microsoft.Extensions.Logging;

namespace DAL;

[SingletonRegistration]
public class RepoFactory : IRepoFactory
{
  private Dictionary<string, object> _factory = new();
  private readonly ILogger<RepoFactory> _logger;

  public RepoFactory(ILogger<RepoFactory> logger)
  {
    _logger = logger;
  }

  public bool Create(object repo)
  {
    if (_factory.Keys.All(o => o != repo.GetType().Name))
    {
      _factory.Add(repo.GetType().Name, repo);
      return true;
    }

    return false;
  }

  public T? Get<T>() where T : class
  {
    if (_factory.ContainsKey(typeof(T).Name))
    {
      return _factory[typeof(T).Name] as T;
    }

    throw new KeyNotFoundException();
  }
}