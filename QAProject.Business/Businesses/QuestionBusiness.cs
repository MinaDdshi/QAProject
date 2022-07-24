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

public class QuestionBusiness : BaseBusiness<Question>
{
	private readonly IUnitOfWork _unitOfWork;

	public QuestionBusiness(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.QuestionRepository!) =>
		_unitOfWork = unitOfWork;

	public async Task<Response?> Upvote(int Id, CancellationToken cancellationToken)
	{
		await _unitOfWork.QuestionRepository!.Upvote(Id);
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
		await _unitOfWork.QuestionRepository!.Downvote(Id);
		await _unitOfWork.CommitAsync(cancellationToken);
		return new Response
		{
			IsSuccess = true,
			ChangedId = Id,
			Message = "Decreased"
		};
	}
}
