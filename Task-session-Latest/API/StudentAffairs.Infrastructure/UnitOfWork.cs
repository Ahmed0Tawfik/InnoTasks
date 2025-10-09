using StudentAffairs.Application.Interfaces;
using StudentAffairs.Infrastructure;

public class UnitOfWork : IUnitOfWork, IAsyncDisposable, IDisposable
{
    private readonly ApplicationDbContext _context;
    private readonly Dictionary<Type, object> _repositories = new();

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public IGenericRepository<T> Repository<T>() where T : BaseEntity
    {
        if (!_repositories.TryGetValue(typeof(T), out var repo))
        {
            repo = new GenericRepository<T>(_context);
            _repositories[typeof(T)] = repo;
        }

        return (IGenericRepository<T>)repo;
    }

    public async Task<int> SaveChangesAsync()
    {
        try
        {
            return await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            throw new ConflictException("The record was modified by another user.");
        }
    }

    public async ValueTask DisposeAsync()
    {
        await _context.DisposeAsync();
        GC.SuppressFinalize(this);
    }

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }
}