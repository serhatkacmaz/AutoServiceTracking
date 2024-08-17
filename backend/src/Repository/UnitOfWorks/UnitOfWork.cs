using Core.Ioc.UnitOfWorks;
using Repository.Contexts;

namespace Repository.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly AutoServiceTrackingContext _context;

    public UnitOfWork(AutoServiceTrackingContext context)
    {
        _context = context;
    }

    public void Commit()
    {
        _context.SaveChanges();
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }
}