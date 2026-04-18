using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CKFS_Management.Entities.VinhHNT.Models;
using CKFS_Management.Repositories.VinhHNT.DBContext;
using Microsoft.EntityFrameworkCore;

namespace CKFS_Management.Repositories.VinhHNT.Base;

public class GenericRepository<T> where T : class
{
    protected CKFS_ManagementContext _context;

    public GenericRepository()
    {
        _context ??= new CKFS_ManagementContext();
    }

    public GenericRepository(CKFS_ManagementContext context)
    {
        _context = context;
    }

    public List<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public void Create(T entity)
    {
        _context.Add(entity);
        _context.SaveChanges();
    }

    public async Task<int> CreateAsync(T entity)
    {
        _context.Add(entity);
        return await _context.SaveChangesAsync();
    }

    public void Update(T entity)
    {
        _context.ChangeTracker.Clear();
        var tracker = _context.Attach(entity);
        tracker.State = EntityState.Modified;
        _context.SaveChanges();
    }

    public async Task<int> UpdateAsync(T entity)
    {
        _context.ChangeTracker.Clear();
        var tracker = _context.Attach(entity);
        tracker.State = EntityState.Modified;
        return await _context.SaveChangesAsync();
    }

    public bool Remove(T entity)
    {
        _context.Remove(entity);
        _context.SaveChanges();
        return true;
    }

    public async Task<bool> RemoveAsync(T entity)
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public T GetById(int id)
    {
        return _context.Set<T>().Find(id);
    }

    public async Task<T> GetByIdAsync(int? id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public void PrepareCreate(T entity) => _context.Add(entity);
    public void PrepareUpdate(T entity)
    {
        var tracker = _context.Attach(entity);
        tracker.State = EntityState.Modified;
    }
    public void PrepareRemove(T entity) => _context.Remove(entity);
    public int Save() => _context.SaveChanges();
    public async Task<int> SaveAsync() => await _context.SaveChangesAsync();
}
