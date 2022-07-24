using QAProject.Business.Contract;
using QAProject.Common.ViewModels;
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

	public async Task<Response?> Create(T t, CancellationToken cancellationToken)
	{
		await _repository.Insert(t, cancellationToken);
		await _unitOfWork.CommitAsync(cancellationToken);
		return new Response
		{
			IsSuccess = true,
			ChangedId = t.Id,
			Message = "Entity Saved"
		};
	}

	public async Task<Response<List<T>>?> ReadAll(SieveModel sieveModel, CancellationToken cancellationToken)
	{
		var data = await _repository.SelectAll(sieveModel, null, cancellationToken);
		await _unitOfWork.CommitAsync(cancellationToken);
		return new Response<List<T>>
		{
			Data = data,
			RecordsTotal = data.Count,
			RecordsFiltered = data.Count,
			Message = "Data Loaded",
			IsSuccess = true
		};
	}

	public async Task<Response?> Update(T t, CancellationToken cancellationToken)
	{
		await _repository.Update(t, cancellationToken);
		await _unitOfWork.CommitAsync(cancellationToken);
		return new Response
		{
			IsSuccess = true,
			ChangedId = t.Id,
			Message = "Entity Updated"
		};
	}

	public async Task<Response?> Delete(T t, CancellationToken cancellationToken)
	{
		await _repository.Delete(t, cancellationToken);
		await _unitOfWork.CommitAsync(cancellationToken);
		return new Response
		{
			IsSuccess = true,
			ChangedId = t.Id,
			Message = "Entity Deleted"
		};
	}

	public async Task<Response?> Delete(int Id, CancellationToken cancellationToken)
	{
		await _repository.Delete(Id, cancellationToken);
		await _unitOfWork.CommitAsync(cancellationToken);
		return new Response
		{
			IsSuccess = true,
			ChangedId = Id,
			Message = "Entity Deleted"
		};
	}
}