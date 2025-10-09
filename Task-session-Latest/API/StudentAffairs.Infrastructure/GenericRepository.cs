
using StudentAffairs.Application.Interfaces;

namespace StudentAffairs.Infrastructure;


public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly ApplicationDbContext _context;

    public GenericRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }


    public async Task<IEnumerable<T>> GetAllAsync() =>
        await _context.Set<T>()
                      .AsNoTracking()
                      .ToListAsync();

    public async Task<T?> GetByIdAsync(Guid id) =>
        await _context.Set<T>().FindAsync(id);

    public async Task<T> AddAsync(T entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        await _context.Set<T>().AddAsync(entity);
        return entity;
    }

    public void Update(T entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        _context.Set<T>().Update(entity);
    }

    public void Delete(T entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        _context.Set<T>().Remove(entity);
    }

  
}

