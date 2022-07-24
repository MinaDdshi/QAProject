using QAProject.Business.Base;
using QAProject.Common.ViewModels;
using QAProject.DataAccess.Contracts;
using QAProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAProject.Business.Businesses;

public class AnswerBusiness : BaseBusiness<Answer>
{
	private readonly IUnitOfWork _unitOfWork;


	public AnswerBusiness(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.AnswerRepository!) =>
		_unitOfWork = unitOfWork;

	public async Task<Response?> Upvote(int Id, CancellationToken cancellationToken)
	{
		await _unitOfWork.AnswerRepository!.Upvote(Id);
		await _unitOfWork.CommitAsync(cancellationToken);
		return new Response
		{
			IsSuccess = true,
			ChangedId = Id,
			Message = "Added"
		};
	}

	public async Task<Response?> Downvote(int Id, CancellationToken cancellationToken)
	{
		await _unitOfWork.AnswerRepository!.Downvote(Id);
		await _unitOfWork.CommitAsync(cancellationToken);
		return new Response
		{
			IsSuccess = true,
			ChangedId = Id,
			Message = "Decreased"
		};
	}

	public async Task<Response?> IsCorrect(int Id, CancellationToken cancellationToken)
	{
		await _unitOfWork.AnswerRepository!.IsCorrect(Id);
		await _unitOfWork.CommitAsync(cancellationToken);
		return new Response
		{
			IsSuccess = true,
			ChangedId = Id,
			Message = "Selected"
		};
	}
}
