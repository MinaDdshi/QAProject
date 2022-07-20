using QAProject.Business.Base;
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

	public async Task Upvote(int Id, CancellationToken cancellationToken)
	{
		await _unitOfWork.AnswerRepository!.Upvote(Id);
		await _unitOfWork.CommitAsync(cancellationToken);
	}

	public async Task Downvote(int Id, CancellationToken cancellationToken)
	{
		await _unitOfWork.AnswerRepository!.Downvote(Id);
		await _unitOfWork.CommitAsync(cancellationToken);
	}

	public async Task IsCorrect(int Id, CancellationToken cancellationToken)
	{
		await _unitOfWork.AnswerRepository!.IsCorrect(Id);
		await _unitOfWork.CommitAsync(cancellationToken);
	}
}
