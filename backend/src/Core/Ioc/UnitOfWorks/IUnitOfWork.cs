namespace Core.Ioc.UnitOfWorks;

public interface IUnitOfWork
{
    public void Commit();
    public Task CommitAsync();
}
