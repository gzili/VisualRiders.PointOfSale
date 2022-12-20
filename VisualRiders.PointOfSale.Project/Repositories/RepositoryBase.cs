using Microsoft.EntityFrameworkCore;

namespace VisualRiders.PointOfSale.Project.Repositories;

public abstract class RepositoryBase<T> where T : class
{
    private readonly PointOfSaleContext _context;

    protected DbSet<T> Items => _context.Set<T>();

    protected RepositoryBase(PointOfSaleContext context)
    {
        _context = context;
    }

    public void Add(T entity)
    {
        Items.Add(entity);
    }

    public List<T> GetAll()
    {
        return Items.ToList();
    }

    public T? GetById(int id)
    {
        return Items.Find(id);
    }

    public void Remove(T entity)
    {
        Items.Remove(entity);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}