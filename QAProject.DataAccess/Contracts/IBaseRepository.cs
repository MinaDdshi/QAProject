using Microsoft.EntityFrameworkCore.Query;
using QAProject.Model.Entities;
using Sieve.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAProject.DataAccess.Contracts;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<T> Insert(T t, CancellationToken cancellationToken);
    Task<List<T>> SelectAll(SieveModel sieveModel, Func<IQueryable<T>, IIncludableQueryable<T, object?>>? include = null, CancellationToken cancellationToken = new());
    Task<T> Update(T t, CancellationToken cancellationToken);
    Task<T> Delete(T t, CancellationToken cancellationToken);
    Task<T> Delete(int Id, CancellationToken cancellationToken);
}
