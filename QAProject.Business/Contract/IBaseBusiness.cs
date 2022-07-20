using QAProject.Model.Entities;
using Sieve.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAProject.Business.Contract;

public interface IBaseBusiness<T> where T : BaseEntity
{
	Task Create(T t, CancellationToken cancellationToken);
	Task<List<T>> ReadAll(SieveModel sieveModel, CancellationToken cancellationToken);
	Task Update(T t, CancellationToken cancellationToken);
	Task Delete(T t, CancellationToken cancellationToken);
	Task Delete(int id, CancellationToken cancellationToken);
}
