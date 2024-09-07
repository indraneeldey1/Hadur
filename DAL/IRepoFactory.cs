namespace DAL;

public interface IRepoFactory
{
  bool Create(object repo);
  T? Get<T>() where T : class;
}