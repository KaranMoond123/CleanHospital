using Application.Interfaces.GenericRepositories;
using Application.Interfaces.UnitOfWorkRepositories;
using Domain.Comman;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Peristance.DataContext;
using System.Collections;

namespace Peristance.Extenstion.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationdbContext _context;
    private readonly IHttpContextAccessor _contextAccessor;
    private Hashtable _repositary;
    private bool disposed;

    public UnitOfWork(ApplicationdbContext context, IHttpContextAccessor contextAccessor)
    {
        _context = context;
        _contextAccessor = contextAccessor;
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        disposed = true;
    }

    public IGenericRepositary<T> Repositary<T>() where T : BaseAuditableEntity
    {
        if (_repositary == null)
            _repositary = new Hashtable();
        var type = typeof(T).Name;
        if (!_repositary.ContainsKey(type))
        {
            var repostaryType = typeof(GenricRepository<>);
            var repostaryInstance = Activator.CreateInstance(repostaryType.MakeGenericType(typeof(T)), _context, _contextAccessor);
            _repositary.Add(type, repostaryInstance);
        }
        return (IGenericRepositary < T > )_repositary[type];
    }

    public Task Rollback()
    {
        throw new NotImplementedException();
    }

    public async Task<int> Save(CancellationToken cancellationToken)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public Task<int> SaveAndRemoveCache(CancellationToken cancellationToken, params string[] cachekeys)
    {
        throw new NotImplementedException();
    }
}
