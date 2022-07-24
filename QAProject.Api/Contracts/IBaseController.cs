using QAProject.Common.ViewModels;
using QAProject.Model.Entities;
using Sieve.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAProject.Api.Contracts;

public interface IBaseController<T> where T : BaseEntity
{
	Task<Response?> Create(T t, CancellationToken cancellationToken);
	Task<Response<List<T>>?> ReadAll(SieveModel sieveModel, CancellationToken cancellationToken);
	Task<Response?> Update(T t, CancellationToken cancellationToken);
	Task<Response?> Delete(T t, CancellationToken cancellationToken);
	Task<Response?> Delete(int Id, CancellationToken cancellationToken);

	void Options();
}