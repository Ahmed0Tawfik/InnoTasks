//EntityFramework8 ORM object relational mapper =>
//DDL(Create table, Alter view, drop table),
//DML(Insert,Select,Update,Delete),
//DCL(Grant Update on table students to wael,revoke)


using System.Diagnostics;

namespace StudentsAffairsWebAPI;

[Route("api/[controller]")]
[ApiController]
public class BaseController<TEntity> : ControllerBase
    where TEntity : BaseEntity
{
    const int maxEntityCount = 15;
    protected readonly StudentsAffairsDbContext _studentsAffairsDbContext;
    public BaseController(StudentsAffairsDbContext studentsAffairsDbContext)
    {
        _studentsAffairsDbContext = studentsAffairsDbContext;

        if (_studentsAffairsDbContext.Set<TEntity>() is null || !_studentsAffairsDbContext.Set<TEntity>().Any())
        {
            FillNormal(maxEntityCount).GetAwaiter().GetResult();

            FillBulk(maxEntityCount).GetAwaiter().GetResult();

        }

    }

    public async Task FillNormal(int desiredCount)
    {
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();

        for (int i = desiredCount + 10; i <= desiredCount + 20; i++)
        {
            TEntity entity = Activator.CreateInstance<TEntity>();

            entity.Name = $"Name{i}";

            Type entityType = typeof(TEntity);

            entityType.GetProperty("Age")?.SetValue(entity, (byte)(30 + i));
            entityType.GetProperty("Mobile")?.SetValue(entity, "124125125");

           await _studentsAffairsDbContext.Set<TEntity>().AddAsync(entity);

        }

        await _studentsAffairsDbContext.SaveChangesAsync();
        stopWatch.Stop();
        Console.WriteLine($"EF Normal SaveChanges: {stopWatch.ElapsedMilliseconds} ms");
    }
    public async Task FillBulk(int desiredCount)
    {
        List<TEntity> listToBeInserted = new List<TEntity>();

        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();

        for (int i = 1; i <= desiredCount; i++)
        {
            TEntity entity = Activator.CreateInstance<TEntity>();

            entity.Name = $"Name{i}";
            
            Type entityType = typeof(TEntity);

            entityType.GetProperty("Age")?.SetValue(entity, (byte)(30 + i));
            entityType.GetProperty("Mobile")?.SetValue(entity, "124125125");

            listToBeInserted.Add(entity);

        }

        // real bulk insert 
        await _studentsAffairsDbContext.BulkInsertAsync(listToBeInserted);

        stopWatch.Stop();
        Console.WriteLine($"EF Bulk SaveChanges: {stopWatch.ElapsedMilliseconds} ms");

    }

    [HttpPost]
    public IActionResult Post([FromBody] TEntity entity)
    {
        _studentsAffairsDbContext.Set<TEntity>().Add(entity);
        _studentsAffairsDbContext.SaveChanges();

        return Created();
    }

    [HttpGet]
    public IEnumerable<TEntity> GetAll()
    {
        return _studentsAffairsDbContext.Set<TEntity>().ToList() ?? new();
    }


    [HttpGet("{id}")]
    public IActionResult GetBuId([FromRoute] string id)
    {
        bool isParsedAsInt = int.TryParse(id, out int idParsed);
        if (!isParsedAsInt)
            return BadRequest($"The value {id} can't be parsed as int");

        try
        {
            TEntity? entityFromDb = _studentsAffairsDbContext.Set<TEntity>().FirstOrDefault(e => e.Id.Equals(idParsed));

            return Ok(entityFromDb);
        }
        catch (Exception exception)
        {
            return NotFound(exception.Message);
        }
    }

    [HttpPut]
    public IActionResult Update([FromBody] TEntity entity)
    {
        if (entity is null || string.IsNullOrEmpty(entity.Name)) throw new Exception("The entity can't be null or its name can't be empty");

        try
        {
            TEntity? entityFromDb = _studentsAffairsDbContext.Set<TEntity>().FirstOrDefault(e => e.Id.Equals(entity.Id));
            
            if (entityFromDb is null) return NotFound(entity);

            var type = typeof(TEntity);

            foreach (var prop in type.GetProperties())
            {
                if (prop.CanWrite)
                {
                    var newValue = prop.GetValue(entity);
                    prop.SetValue(entityFromDb, newValue);
                }
            }

            //use reflections to read and set props 
            //entityFromDb.Name = entity.Name;
            //entityFromDb.Age = entity.Age;
            //entityFromDb.Mobile = entity.Mobile;

            _studentsAffairsDbContext.Set<TEntity>().Update(entityFromDb);
            _studentsAffairsDbContext.SaveChanges();

            return Ok(entityFromDb);
        }
        catch (Exception exception)
        {
            return NotFound(exception.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] string id)
    {
        bool isParsedAsInt = int.TryParse(id, out int idParsed);
        if (!isParsedAsInt)
            return BadRequest($"The value {id} can't be parsed as int");

        try
        {
            TEntity? toBeDeletedEntity = _studentsAffairsDbContext.Set<TEntity>().FirstOrDefault(e => e.Id.Equals(idParsed));

            if (toBeDeletedEntity is not null)
            {
                _studentsAffairsDbContext.Set<TEntity>().Remove(toBeDeletedEntity);
                _studentsAffairsDbContext.SaveChanges();
            }

            return Ok(toBeDeletedEntity);
        }
        catch (Exception exception)
        {
            return NotFound(exception.Message);
        }
    }
    [HttpDelete]
    public IActionResult Delete([FromBody] TEntity entity)
    {
        if (entity is null) throw new Exception("The entity can't be null");

        try
        {
            TEntity? entityFromDb = _studentsAffairsDbContext.Set<TEntity>().FirstOrDefault(e => e.Id.Equals(entity.Id));
            if (entityFromDb is null) return NotFound(entity);

            _studentsAffairsDbContext.Set<TEntity>().Remove(entityFromDb);
            _studentsAffairsDbContext.SaveChanges();

            return Ok(entity);
        }
        catch (Exception exception)
        {
            return NotFound(exception.Message);
        }
    }
}
