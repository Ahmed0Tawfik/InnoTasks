namespace StudentAffairs.Infrastructure;

public class UnitOfWork : IUnitOfWork, IAsyncDisposable, IDisposable
{
    private readonly ApplicationDbContext _context;
    private readonly Dictionary<Type, object> _repositories = new();
    private IDbContextTransaction? _transaction;

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

    public async Task BeginTransactionAsync()
    {
        _transaction = await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitAsync()
    {
        try
        {
            await _context.SaveChangesAsync();
            await _transaction?.CommitAsync()!;
        }
        catch
        {
            await RollbackAsync();
            throw;
        }
    }

    public async Task RollbackAsync()
    {
        await _transaction?.RollbackAsync()!;
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
        if (_transaction != null)
            await _transaction.DisposeAsync();

        await _context.DisposeAsync();
        GC.SuppressFinalize(this);
    }

    public void Dispose()
    {
        _transaction?.Dispose();
        _context.Dispose();
        GC.SuppressFinalize(this);
    }
}
