using QAProject.Business.Contract;
using QAProject.DataAccess.Contracts;
using QAProject.Model.Entities;
using Sieve.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAProject.Business.Base;

public class BaseBusiness<T> : IBaseBusiness<T> where T : BaseEntity
{
	private readonly IUnitOfWork _unitOfWork;

	private readonly IBaseRepository<T> _repository;

	public BaseBusiness(IUnitOfWork unitOfWork, IBaseRepository<T> repository)
	{
		_unitOfWork = unitOfWork;
		_repository = repository;
	}

	public async Task Create(T t, CancellationToken cancellationToken)
	{
		await _repository.Insert(t, cancellationToken);
		await _unitOfWork.CommitAsync(cancellationToken);
	}

	public async Task<List<T>> ReadAll(SieveModel sieveModel, CancellationToken cancellationToken)
	{
		var data = await _repository.SelectAll(sieveModel, null, cancellationToken);
		await _unitOfWork.CommitAsync(cancellationToken);
		return data;
		
	}
	public async Task Update(T t, CancellationToken cancellationToken)
	{
		await _repository.Update(t, cancellationToken);
		await _unitOfWork.CommitAsync(cancellationToken);
	}

	public async Task Delete(T t, CancellationToken cancellationToken)
	{
		await _repository.Delete(t, cancellationToken);
		await _unitOfWork.CommitAsync(cancellationToken);
	}

	public async Task Delete(int id, CancellationToken cancellationToken)
	{
		await _repository.Delete(id, cancellationToken);
		await _unitOfWork.CommitAsync(cancellationToken);
	}
}