using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using QAProject.DataAccess.Context;
using QAProject.DataAccess.Contracts;
using QAProject.Model.Entities;
using Sieve.Models;
using Sieve.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAProject.DataAccess.Base;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    private readonly DbSet<T> _dbSet;
    private readonly ISieveProcessor _processor;

    public BaseRepository(QAProjectContext context, ISieveProcessor processor)
    {
        _dbSet = context.Set<T>();
        _processor = processor;
    }

    public async Task<T> Insert(T t, CancellationToken cancellationToken = new())
    {
        var filan = (await _dbSet.AddAsync(t, cancellationToken)).Entity;
        return filan;
    }


    public async Task<List<T>> SelectAll(SieveModel sieveModel, Func<IQueryable<T>, IIncludableQueryable<T, object?>>? include = null,
        CancellationToken cancellationToken = new())
    {
        var query = _dbSet.AsNoTracking();
        if (include != null)
            query = include(query);
        return await _processor.Apply(sieveModel, query).ToListAsync(cancellationToken);
    }

    public async Task<T> Update(T t, CancellationToken cancellationToken = new())
    {
        t.LastUpdated = DateTime.Now;
        return (await Task.FromResult(_dbSet.Update(t))).Entity;
    }

    public async Task<T> Delete(T t, CancellationToken cancellationToken = new())
    {
        t.IsDeleted = true;
        return (await Task.FromResult(_dbSet.Update(t))).Entity;
    }

    public async Task<T> Delete(int Id, CancellationToken cancellationToken = new())
    {
        var record = await _dbSet.SingleOrDefaultAsync(x => x.Id == Id, cancellationToken);
        if (record != null)
        {
            record.IsDeleted = true;
            return (await Task.FromResult(_dbSet.Update(record))).Entity;
        }
        return Activator.CreateInstance<T>();
    }
}