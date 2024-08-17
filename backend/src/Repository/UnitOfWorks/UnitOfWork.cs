using Core.Ioc.UnitOfWorks;
using Repository.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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